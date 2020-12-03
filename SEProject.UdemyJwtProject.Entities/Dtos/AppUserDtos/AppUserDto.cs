using SEProject.UdemyJwtProject.Entities.Interfaces;
using System.Collections.Generic;

namespace SEProject.UdemyJwtProject.Entities.Dtos.AppUserDtos
{
    public class AppUserDto : IDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}