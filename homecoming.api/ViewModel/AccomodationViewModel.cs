using homecoming.api.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homecoming.api.ViewModel
{
    public class AccomodationViewModel
    {
        public int AccomodationId { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public string AccomodationName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public List<ListingImage> AccomodationList { get; set; }
        public IFormFileCollection ImageList { get; set; }
    }
}
