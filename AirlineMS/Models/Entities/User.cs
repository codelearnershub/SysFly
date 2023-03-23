namespace AirlineMS.Models.Entities
{
    public class User :BaseEntity
    {
        public string FirsttName{ get;set;}
        public string LastName{ get;set;}
        public string PhoneNumber{ get;set;}
        public string Email{ get;set;}
        public string Password{ get;set;}
        public List<UserRole> UserRoles{ get;set;}
    }
}