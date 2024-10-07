using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class Share
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Share(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
