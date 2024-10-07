using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class TraderWithFilter : IObserver
    {
        public string Name { get; set; }
        private double PriceLimit { get; set; }
        public TraderWithFilter(string name, double priceLimit)
        {
            Name = name;
            PriceLimit = priceLimit;
        }
        public async Task UpdateAsync(string name, double price)
        {
            await Task.Delay(1000);
            if (PriceLimit <= price)
            {
                Console.WriteLine($"The '{name}' share price changed to {price}.");
            }
        }
    }
}
