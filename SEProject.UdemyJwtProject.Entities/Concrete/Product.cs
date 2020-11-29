using SEProject.UdemyJwtProject.Entities.Interfaces;

namespace SEProject.UdemyJwtProject.Entities.Concrete
{
    public class Product : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}