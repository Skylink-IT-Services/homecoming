using homecoming.api.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homecoming.api.ViewModel
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        public int AccomodationId { get; set; }
        public Accomodation Accomodation { get; set; }
        public string RoomType { get; set; }
        public string BathRoom { get; set; }
        public Decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public List<RoomImage> RoomList { get; set; }
        public IFormFileCollection ImageList { get; set; }
    }
}
