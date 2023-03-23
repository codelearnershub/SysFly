namespace AirlineMS.Models.Entities
{
    public class Role:BaseEntity
    {
        public string RoleName{get;set;}
        public string Description{get;set;}
        public List<UserRole> UserRoles{get;set;}
    }
}