namespace InsuranceCompany_api.Data.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<UserProduct> userProductColl { get; set; }

    }
}
