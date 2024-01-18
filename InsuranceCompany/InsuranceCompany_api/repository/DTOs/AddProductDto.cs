using InsuranceCompany_api.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCompany_api.repository.DTOs
{
    public class AddProductDto
    {
        [StringLength(50, MinimumLength = 15, ErrorMessage = "Name must be between 15 and 50 characters")]
        public string Name { get; set; }
        public Category category { get; set; }
        public Data.Entity.Type type { get; set; }
        public typeOfInsurance typeOfInsurance { get; set; }
        //public decimal Bonus { get; set; }
        [MinLength(10, ErrorMessage = "Description must be at least 1000 characters")]
        public string TermsDescription { get; set; }

        //public decimal CalculatePremium(Category productCategory, Data.Entity.Type productType)
        //{
        //    if (productCategory == Category.TravelInsurance && productType == Data.Entity.Type.PLatinum)
        //    {
        //        return 200;
        //    }

        //    return 100;
        //}

    }

}
