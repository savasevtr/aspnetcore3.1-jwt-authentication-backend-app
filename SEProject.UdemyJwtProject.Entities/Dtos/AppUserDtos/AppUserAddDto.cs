using SEProject.UdemyJwtProject.Entities.Interfaces;

namespace SEProject.UdemyJwtProject.Entities.Dtos.AppUserDtos
{
    public class AppUserAddDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}