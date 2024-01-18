using InsuranceCompany_api.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace InsuranceCompany_api.repository.DTOs
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 15, ErrorMessage = "Name must be between 15 and 50 characters")]
        public string Name { get; set; }

        [MinLength(10, ErrorMessage = "Description must be at least 1000 characters")]
        public string TermsDescription { get; set; }
    }
}
