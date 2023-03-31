namespace AirlineMS.Models.Dtos
{
    public class PassengerDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
        public List<FlightDto> Flight { get; set; }
    }

    public class CreatePassengerRequestModel
    {
        [MaxLength(50), MinLength(5)]
        public string FirstName{ get;set;}

        [Required]
        [MaxLength(50), MinLength(5)]
        public string LastName{ get;set;}
        [Required]
        [MaxLength(50), MinLength(10)]
        public string PhoneNumber{ get;set;}
        [Required]
        public string Email{ get;set;}
        [Required]
        public string Password{ get;set;}
    }

     public class UpdatePassengerRequestModel
    {
        [Required]
        [MaxLength(50), MinLength(5)]
        public string FirstName{ get;set;}
        [Required]
        [MaxLength(50), MinLength(5)]

        public string LastName{ get;set;}
        
        [Required]
        [MaxLength(50), MinLength(10)]
        public string PhoneNumber{ get;set;}
    }
}