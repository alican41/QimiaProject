using Microsoft.EntityFrameworkCore;
using QimiaProject.DataAccess.Entities;
using QimiaProject.DataAccess.Repositories.Abstractions;

namespace QimiaProject.DataAccess.Repositories.Implementations;

public class RequestRepository : RepositoryBase<Request> , IRequestRepository
{
  
    public RequestRepository(QimiaProjectDbContext dbContext) : base(dbContext)
    {
       
    }

   
}
