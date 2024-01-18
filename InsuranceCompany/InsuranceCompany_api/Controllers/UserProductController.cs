using InsuranceCompany_api.repository;
using InsuranceCompany_api.repository.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProductController : ControllerBase
    {
        private readonly IUserProductRepository _userProductRepository;

        public UserProductController(IUserProductRepository userProductRepository)
        {
            _userProductRepository = userProductRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetSoldProductList()
        {
            var result = await _userProductRepository.GetProductAndUserInformationAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRelationships(userProductDto userProduct)
        {
            var result = await _userProductRepository.registerRelationships(userProduct);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> updateUser(int Id, userProductDto userProduct)
        {
            var result = await _userProductRepository.updateUserProduct(Id, userProduct);
            return Ok(result);
        }


    }
}
