using SEProject.UdemyJwtProject.DataAccess.Interfaces;
using SEProject.UdemyJwtProject.Entities.Concrete;

namespace SEProject.UdemyJwtProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
    }
}