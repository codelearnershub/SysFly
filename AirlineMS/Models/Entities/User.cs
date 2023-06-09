namespace AirlineMS.Models.Entities
{
    public class User :BaseEntity
    {
        public string FirstName{ get;set;}
        public string LastName{ get;set;}
        public string PhoneNumber{ get;set;}
        public string Email{ get;set;}
        public string Password{ get;set;}
        public double Wallet{get;set;}
        public ICollection<UserRole> UserRoles{ get;set;} = new HashSet<UserRole>();
    }
}