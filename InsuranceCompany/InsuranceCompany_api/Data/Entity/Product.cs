using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace InsuranceCompany_api.Data.Entity
{
    public class Product 
    {
        public int Id { get; set; }
        [StringLength (50, MinimumLength =15, ErrorMessage = "Name must be between 15 and 50 characters")]
        public string Name { get; set; }
        public Category category { get; set; }
        public Type type { get; set; }
        public typeOfInsurance typeOfInsurance { get; set; }
        public decimal Bonus { get; set; }
        [MinLength(10, ErrorMessage = "Description must be at least 1000 characters")]
        public string TermsDescription { get; set; }

        public virtual ICollection<UserProduct> userProductColl { get; set; }
    }


    public enum Category
    {
        HealthInsurance,
        TravelInsurance,
        CarInsurance     
    }

    public enum Type
    {
       Silver,
       Gold,
       PLatinum
    }

    public enum typeOfInsurance
    {
        Family,
        Individual,
        Corporate
    }
}
