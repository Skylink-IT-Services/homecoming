using System;

namespace homecoming.webapp.Models
{
    public class Business
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string CoverPhotoUrl { get; set; }
        public string Tel_No { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Province { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
