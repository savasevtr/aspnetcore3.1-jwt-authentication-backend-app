using SEProject.UdemyJwtProject.Entities.Concrete;
using System.Collections.Generic;

namespace SEProject.UdemyJwtProject.Business.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwt(AppUser appUser, List<AppRole> appRoles);
    }
}