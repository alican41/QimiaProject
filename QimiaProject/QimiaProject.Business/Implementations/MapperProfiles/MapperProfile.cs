using AutoMapper;
using QimiaProject.Business.Implementations.Queries.Book.Dtos;
using QimiaProject.Business.Implementations.Queries.Request.Dtos;
using QimiaProject.Business.Implementations.Queries.Reservation.Dtos;
using QimiaProject.Business.Implementations.Queries.User.Dtos;
using QimiaProject.DataAccess.Entities;

namespace QimiaProject.Business.Implementations.MapperProfiles;

public class MapperProfile : Profile
{
    public MapperProfile() 
    {
        CreateMap<User, UserDto>()
            ;
        CreateMap<Book, BookDto>()
            ;
        CreateMap<Reservation, ReservationDto>()
            ;
        CreateMap<Request, RequestDto>()
            ;
        
    }
}
