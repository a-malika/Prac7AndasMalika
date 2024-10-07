using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Share share1 = new Share("Google", 1230);
            Share share2 = new Share("Microsoft", 1450);
            Share share3 = new Share("Amazon", 1111);
            StockExchange exchange = new StockExchange();
            exchange.AddShare(share1);
            exchange.AddShare(share2);
            exchange.AddShare(share3);
            Trader observer1 = new Trader("Anton");
            TraderWithFilter observer2 = new TraderWithFilter("Dora", 1000);
            AutomaticTradingRobot observer3 = new AutomaticTradingRobot("Chuchu");
            exchange.RegisterObserver(observer1, share1);
            exchange.RegisterObserver(observer2, share2);
            exchange.RegisterObserver(observer2, share3);
            exchange.RegisterObserver(observer3, share1);
            exchange.RegisterObserver(observer3, share2);
            exchange.RegisterObserver(observer3, share3);
            Random random = new Random();
            while (true)
            {
                Thread.Sleep(3000);
                int n = random.Next(1, 4);
                if (n == 1)
                {
                    exchange.UpdateStock(share1, random.Next(500, 2000));
                }
                else if (n == 2)
                {
                    exchange.UpdateStock(share2, random.Next(500, 2000));
                }
                else if (n == 3)
                {
                    exchange.UpdateStock(share3, random.Next(500, 2000));
                }
            }
        }
    }
}
