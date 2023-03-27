using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineMS.Models.Dtos
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UserDto> user { get; set; }
    }

    public class CreateRoleRequestModel
    {
        [Required]
        [MaxLength(25), MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MaxLength(225), MinLength(5)]
        public string Description { get; set; }
    }
    public class UpdateRoleRequestModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(225), MinLength(5)]
        public string Description { get; set; }
    }
}