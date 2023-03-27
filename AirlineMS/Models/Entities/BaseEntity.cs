using System;

namespace AirlineMS.Models.Entities
{
    public class BaseEntity
    {
        public string Id{get; set;} = Guid.NewGuid().ToString();
        public bool IsDeleted{get;set;}
        public DateTime DateCreated{get; set;}
        public DateTime CreatedBy{get; set;}
    }
}