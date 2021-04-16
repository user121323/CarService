using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Models
{
    public class Chat
    {
        public long Id { get; set; }
        public user sender { get; set; }
        public user recipient { get; set; }
        public String message { get; set; }
        public DateTime date { get; set; }
    }
}
