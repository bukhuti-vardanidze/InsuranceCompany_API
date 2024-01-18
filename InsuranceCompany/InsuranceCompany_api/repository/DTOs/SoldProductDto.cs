using InsuranceCompany_api.Data.Entity;

namespace InsuranceCompany_api.repository.DTOs
{
    public class SoldProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Category ProductCategory { get; set; }
        public Data.Entity.Type ProductType { get; set; }
        public typeOfInsurance ProductTypeOfInsurance { get; set; }
        public decimal ProductBonus { get; set; }
        public string ProductTermsDescription { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPersonalNumber { get; set; }
        public string UserPhone { get; set; }
    }
}
