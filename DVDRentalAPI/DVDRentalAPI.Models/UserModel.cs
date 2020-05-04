using System;
namespace DVDRentalAPI.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public string StreetName { get; set; }
        public string AptNo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string JwtToken { get; set; }
    }
}
