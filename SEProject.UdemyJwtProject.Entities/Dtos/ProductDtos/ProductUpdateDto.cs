using SEProject.UdemyJwtProject.Entities.Interfaces;

namespace SEProject.UdemyJwtProject.Entities.Dtos.ProductDtos
{
    public class ProductUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}