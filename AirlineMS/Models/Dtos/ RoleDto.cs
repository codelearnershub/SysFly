using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Dtos
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public List<UserRoleDto> userRoles { get; set; }
    }

    public class CreateRoleRequestModel
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
    public class UpdateRoleRequestModel
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}