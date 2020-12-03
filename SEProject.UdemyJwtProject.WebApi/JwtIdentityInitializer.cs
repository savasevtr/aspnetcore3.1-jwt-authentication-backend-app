using SEProject.UdemyJwtProject.Business.Interfaces;
using SEProject.UdemyJwtProject.Business.StringInfos;
using SEProject.UdemyJwtProject.Entities.Concrete;
using System.Threading.Tasks;

namespace SEProject.UdemyJwtProject.WebApi
{
    public static class JwtIdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            var adminRole = await appRoleService.FindByName(RoleInfo.Admin);

            if (adminRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Admin
                });
            }

            var memberRole = await appRoleService.FindByName(RoleInfo.Member);

            if (memberRole == null)
            {
                await appRoleService.Add(new AppRole
                {
                    Name = RoleInfo.Member
                });
            }

            var adminUser = await appUserService.FindByUserName("savas.ev");

            if (adminUser == null)
            {
                await appUserService.Add(new AppUser
                {
                    FullName = "Savaş Ev",
                    UserName = "savas.ev",
                    Password = "12345"
                });

                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var user = await appUserService.FindByUserName("savas.ev");

                await appUserRoleService.Add(new AppUserRole
                {
                    AppUserId = user.Id,
                    AppRoleId = role.Id
                });
            }
        }
    }
}