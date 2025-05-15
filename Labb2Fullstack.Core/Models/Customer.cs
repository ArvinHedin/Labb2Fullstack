using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Fullstack.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Förnamn { get; set; }
        public string? Efternamn { get; set; }
        public string? Email { get; set; }
        public string? Mobilnummer { get; set; }
        public string? Adress { get; set; }
    }

}
