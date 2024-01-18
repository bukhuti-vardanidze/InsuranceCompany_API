using InsuranceCompany_api.Data;
using InsuranceCompany_api.Data.Entity;
using InsuranceCompany_api.repository.DTOs;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany_api.repository
{
    public interface IProductRepository
    {
        Task<Product> addProduct(AddProductDto addProductDto);
        Task<Product> updateProduct(UpdateProductDto updateProductDto);
        Task<Product> GetProductById(int Id);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> addProduct(AddProductDto addProductDto)
        {
            var result = new Product()
            {
                Name = addProductDto.Name,
                type = addProductDto.type,
                category = addProductDto.category,
                typeOfInsurance = addProductDto.typeOfInsurance,
                Bonus = CalculatePremium(addProductDto.category, addProductDto.type),
                TermsDescription = addProductDto.TermsDescription
            };

            _context.Products.Add(result);
            await _context.SaveChangesAsync();
            
            return result;
        }

        private decimal CalculatePremium(Category productCategory, Data.Entity.Type productType)
        {
            if (productCategory == Category.TravelInsurance && productType == Data.Entity.Type.PLatinum)
            {
                return 200;
            }

            return 100;
        }


        public async Task<Product> updateProduct(UpdateProductDto updateProductDto)
        {
            var existingProduct = await _context.Products.FindAsync(updateProductDto.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = updateProductDto.Name;
                existingProduct.TermsDescription = updateProductDto.TermsDescription;

                await _context.SaveChangesAsync();
            }

            return existingProduct;

        }

       public async Task<Product> GetProductById(int Id)
        {
          
            var result =await _context.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
            return result;


        }

    }


}
