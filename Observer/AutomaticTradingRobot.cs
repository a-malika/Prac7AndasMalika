using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class AutomaticTradingRobot : IObserver
    {
        public string Name { get; set; }
        public AutomaticTradingRobot(string name)
        {
            Name = name;
        }
        public async Task UpdateAsync(string name, double price)
        {
            await Task.Delay(1000);
            if (price <= 700)
                Console.WriteLine($"Buying a '{name}' share at a price of {price}.");
            else if (price >= 1500)
                Console.WriteLine($"Selling shares of '{name}' at a price of {price}.");
            else
                Console.WriteLine($"Waiting for the price to change. The current share price of '{name}' is {price}.");
        }
    }
}
