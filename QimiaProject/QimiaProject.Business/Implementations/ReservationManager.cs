using QimiaProject.Business.Abstracts;
using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Repositories.Abstractions;
using System.Linq;

namespace QimiaProject.Business.Implementations;

public class ReservationManager : IReservationManager
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IAuthManager _authManager;
    private readonly IUserRepository _userRepository;

    public ReservationManager(
        IReservationRepository reservationRepository,
        IBookRepository bookRepository,
        IAuthManager authManager,
        IUserRepository userRepository)
    {
        _reservationRepository = reservationRepository;
        _bookRepository = bookRepository;
        _authManager = authManager;
        _userRepository = userRepository;
    }

    public Task<List<Reservation>> GetAllReservationsAsync(CancellationToken cancellationToken)
    {
        return _reservationRepository.GetAllAsync(cancellationToken);
    }

    public async Task CreateReservationAsync(
        Reservation reservation,
        CancellationToken cancellationToken)
    {
        reservation.ReservationId = default;
        var reservations = await _reservationRepository.GetAllAsync(cancellationToken);
        var freebooks = await _bookRepository.GetByBookNameAsync(reservation.BookName, reservation.BookAuthor, cancellationToken);
        if(reservations != null) 
        {
            var firstAvailableBook = freebooks.FirstOrDefault(book =>
            {
                // Kitabın rezervasyonları arasında tarih kontrolü yapın
                var reservationsForBook = reservations.Where(r =>
                    r.BookName == book.BookName &&
                    r.BookAuthor == book.BookAuthor).ToList();

                // Eğer kitabın hiç rezervasyonu yoksa, bu kitabı alın
                if (!reservationsForBook.Any())
                    return true;

                // Kitabın rezervasyonları arasında tarih kontrolü yapın
                return !reservationsForBook.Any(r =>
                (r.ReservationEndDate < reservation.ReservationStartDate &&
                r.ReservationEndDate < reservation.ReservationEndDate) ||
                (r.ReservationStartDate > reservation.ReservationStartDate &&
                r.ReservationStartDate > reservation.ReservationEndDate));
            });
            if (firstAvailableBook != null)
            {
                reservation.BookId = firstAvailableBook.BookId;
                reservation.ReservationEndDate = reservation.ReservationStartDate.AddDays(14);
                await _reservationRepository.CreateAsync(reservation, cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("Uygun kitap bulunamadı!!");
            }
        }
        else
        {
            var anyReservationGetFirstBook = freebooks.FirstOrDefault(book =>
                book.BookName == reservation.BookName && 
                book.BookAuthor == reservation.BookAuthor);

            if (anyReservationGetFirstBook != null)
            {
                reservation.BookId = anyReservationGetFirstBook.BookId;
                reservation.ReservationEndDate = reservation.ReservationStartDate.AddDays(14);
                await _reservationRepository.CreateAsync(reservation, cancellationToken);
            }
            else
            {
                throw new InvalidOperationException("Uygun kitap bulunamadı!!");
            }
        }
        
        
        
        
    }

    public async Task<Reservation> GetReservationByIdAsync(
        int reservationId,
        CancellationToken cancellationToken)
    {
        var reservation = await _reservationRepository.GetByIdAsync(reservationId, cancellationToken);

        return reservation;
    }

    public async Task DeleteReservationByIdAsync(
        int reservationId,
        CancellationToken cancellationToken)
    {
        await _reservationRepository.DeleteByIdAsync(reservationId, cancellationToken);
    }

    public async Task UpdateReservationAsync(
        Reservation reservation,
        CancellationToken cancellationToken)
    {
        var userEmail =await _authManager.GetUserEmail();
        var oldUser =await _userRepository.GetByUserEmailAsync(userEmail, cancellationToken);
        if(reservation.UserNo == oldUser.UserNo) 
            {
            var oldReservation = await _reservationRepository.GetByIdAsync(reservation.ReservationId, cancellationToken);
            var book = await _bookRepository.GetByIdAsync(oldReservation.BookId, cancellationToken);
            var reservations = await _reservationRepository.GetAllAsync(cancellationToken);

            if (reservations.Any())
            {
                var reservationsForBook = reservations.Where(r =>
                    r.BookId == oldReservation.BookId &&
                    r.ReservationId != oldReservation.ReservationId).ToList();

                // Kitabın rezervasyonları arasında tarih kontrolü yapın
                var isAvailable = !reservationsForBook.Any(r =>
                    (r.ReservationEndDate >= reservation.ReservationStartDate &&
                    r.ReservationStartDate <= reservation.ReservationStartDate) ||
                    (r.ReservationStartDate <= reservation.ReservationEndDate &&
                    r.ReservationEndDate >= reservation.ReservationEndDate));

                // Eğer kitabın hiç rezervasyonu yoksa, bu kitabı alın
                if (isAvailable)
                    await _reservationRepository.UpdateAsync(reservation, cancellationToken);
                else
                    throw new InvalidOperationException("Bu Tarihler arasında rezervasyon yapamazsınız!!");
            }
            else
            {
                await _reservationRepository.UpdateAsync(reservation, cancellationToken);
            }
        }
        else
        {
            throw new InvalidOperationException("Sizden başka bir kullanıcının rezervasyon işlemini gerçekleştiremezsiniz");
        }
        

    }
}
