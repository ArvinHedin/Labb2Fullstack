using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Fullstack.Core.DTO
{
    public class OrderCreateModel
    {
        public int CustomerId { get; set; }
        public DateTime OrderDatum { get; set; }
        public List<OrderItemCreateModel> OrderItems { get; set; }

    }
}
