using SEProject.UdemyJwtProject.Entities.Concrete;
using System.Threading.Tasks;

namespace SEProject.UdemyJwtProject.Business.Interfaces
{
    public interface IAppRoleService : IGenericService<AppRole>
    {
        Task<AppRole> FindByName(string roleName);
    }
}