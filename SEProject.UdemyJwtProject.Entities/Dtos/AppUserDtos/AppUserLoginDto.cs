using SEProject.UdemyJwtProject.Entities.Interfaces;

namespace SEProject.UdemyJwtProject.Entities.Dtos.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}