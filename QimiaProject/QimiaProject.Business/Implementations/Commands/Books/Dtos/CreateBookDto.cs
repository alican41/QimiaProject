
namespace QimiaProject.Business.Implementations.Commands.Books.Dtos;

public class CreateBookDto
{
    public string? BookName { get; set; }
    public string? BookAuthor { get; set; }
   
    //bookstatus kısmını create yaparken otomatik atayacağım
}
