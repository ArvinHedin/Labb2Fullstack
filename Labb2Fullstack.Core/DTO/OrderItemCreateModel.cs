using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Fullstack.Core.DTO
{
    public class OrderItemCreateModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
