﻿using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
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
        [ServiceFilter(typeof(ValidId<Product>))]
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
            await _productService.Add(_mapper.Map<Product>(productAddDto));

            return Created("", productAddDto);
        }

        [HttpPut]
        [ValidModel]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _productService.Update(_mapper.Map<Product>(productUpdateDto));

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