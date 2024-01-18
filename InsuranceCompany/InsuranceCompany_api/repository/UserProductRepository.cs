using InsuranceCompany_api.Data;
using InsuranceCompany_api.Data.Entity;
using InsuranceCompany_api.repository.DTOs;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany_api.repository
{
    public interface IUserProductRepository
    {
        Task<List<SoldProductDto>> GetProductAndUserInformationAsync();
        Task<UserProduct> registerRelationships(userProductDto userProduct);
        Task<UserProduct> updateUserProduct(int id, userProductDto userProduct);
    }
    public class UserProductRepository : IUserProductRepository
    {
        private readonly DataContext _context;

        public UserProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SoldProductDto>> GetProductAndUserInformationAsync()
        {
            var result = await _context.UserProducts
                .Include(x => x.Product)
                .Include(x => x.User)
                .Select(up => new SoldProductDto
                {
                    ProductId = up.Product.Id,
                    ProductName = up.Product.Name,
                    ProductCategory = up.Product.category,
                    ProductType = up.Product.type,
                    ProductTypeOfInsurance = up.Product.typeOfInsurance,
                    ProductBonus = up.Product.Bonus,
                    ProductTermsDescription = up.Product.TermsDescription,
                    UserId = up.User.Id,
                    UserName = up.User.FirstName + " " + up.User.LastName,
                    UserPersonalNumber = up.User.PersonalNumber,
                    UserPhone = up.User.Phone
                })
                .ToListAsync();

            return  result;
        }

        public async Task<UserProduct> registerRelationships(userProductDto userProduct)
        {
            var result = new UserProduct()
            {
                UserId = userProduct.UserId,
                ProductId = userProduct.ProductId
            };

            _context.UserProducts.Add(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<UserProduct> updateUserProduct(int id,userProductDto userProduct)
        {
           var checkUserProduct = await _context.UserProducts.Where(x=>x.Id == id).FirstOrDefaultAsync();   
            if(checkUserProduct != null)
            {
                checkUserProduct.UserId = userProduct.UserId;
                checkUserProduct.ProductId = userProduct.ProductId;
            }

            await _context.SaveChangesAsync();
            return checkUserProduct;

        }


    }
}
