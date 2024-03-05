using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapingML.Model
{
    public  class Produto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Freight { get; set; }
        public string Photo { get; set; }
        public string Link { get; set; }
    }
}
