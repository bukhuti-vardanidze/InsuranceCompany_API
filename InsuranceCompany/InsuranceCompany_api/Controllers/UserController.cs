using InsuranceCompany_api.repository;
using InsuranceCompany_api.repository.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRespository _userRespository;

        public UserController(IUserRespository userRespository)
        {
           _userRespository = userRespository;
        }


        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserDtos addUser)
        {
            try
            {
                if (addUser == null)
                {
                    return BadRequest("Invalid data provided for user creation.");
                }

                var result = await _userRespository.AddUser(addUser);

                return Ok(result);

            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }



    }
}
