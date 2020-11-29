using SEProject.UdemyJwtProject.Entities.Interfaces;
using System.Collections.Generic;

namespace SEProject.UdemyJwtProject.Entities.Concrete
{
    public class AppRole : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}