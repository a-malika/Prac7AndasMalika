using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class Trader : IObserver
    {
        public string Name { get; set; }
        public Trader(string name)
        {
            Name = name;
        }
        public async Task UpdateAsync(string name, double price)
        {
            await Task.Delay(1000);
            Console.WriteLine($"The '{name}' share price changed to {price}.");
        }
    }
}
