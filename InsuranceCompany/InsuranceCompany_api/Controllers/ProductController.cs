using InsuranceCompany_api.repository;
using InsuranceCompany_api.repository.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromQuery]AddProductDto addProduct)
        {
            var result =await _productRepository.addProduct(addProduct);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromQuery] UpdateProductDto updateProduct)
        {
            try
            {
                var updatedProduct = await _productRepository.updateProduct(updateProduct);

                if (updatedProduct != null)
                {
                    return Ok(updatedProduct);
                }
                else
                {
                    return NotFound($"Product with ID {updateProduct.Id} not found.");
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var result = await _productRepository.GetProductById(Id);
            return Ok(result);
        }

       

    }
}
