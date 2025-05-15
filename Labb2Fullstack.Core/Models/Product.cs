using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Fullstack.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Produktnummer { get; set; }
        public string? Produktnamn { get; set; }
        public string? Produktbeskrivning { get; set; }
        public decimal Pris { get; set; }
        public string? Produktkategori { get; set; }
        public bool ÄrUtgått { get; set; }
    }

}
