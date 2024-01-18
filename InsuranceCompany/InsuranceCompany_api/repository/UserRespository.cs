using InsuranceCompany_api.Data;
using InsuranceCompany_api.Data.Entity;
using InsuranceCompany_api.repository.DTOs;

namespace InsuranceCompany_api.repository
{
    public interface IUserRespository
    {
        Task<User> AddUser(AddUserDtos addUser);
    }
    public class UserRespository : IUserRespository
    {
        private readonly DataContext _context;

        public UserRespository(DataContext context) 
        {
            _context = context;
        }


        public async Task<User> AddUser(AddUserDtos addUser)
        {
            var result = new User()
            {
                FirstName = addUser.FirstName,
                LastName = addUser.LastName,
                PersonalNumber = addUser.PersonalNumber,
                Phone = addUser.Phone
            };

            _context.Users.Add(result);
            await _context.SaveChangesAsync();

            return result;
        }


      

    }
}
