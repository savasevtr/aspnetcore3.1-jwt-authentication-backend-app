using Microsoft.AspNetCore.Mvc;
using SEProject.UdemyJwtProject.Business.Interfaces;
using SEProject.UdemyJwtProject.Entities.Concrete;
using SEProject.UdemyJwtProject.Entities.Dtos.ProductDtos;
using SEProject.UdemyJwtProject.WebApi.CustomFilters;
using System.Threading.Tasks;

namespace SEProject.UdemyJwtProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();

            return Ok(products);
        }

        //api/products/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            await _productService.Add(new Product { Name = productAddDto.Name });

            return Created("", productAddDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await _productService.Update(product);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Remove(new Product() { Id = id });

            return NoContent();
        }
    }
}