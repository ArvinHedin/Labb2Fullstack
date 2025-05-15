using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Labb2Fullstack.Core.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Antal { get; set; }
        public Product Product { get; set; }
        
        [JsonIgnore]
        public Order Order { get; set; }
    }
}
