using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice7
{
    public class StockExchange : ISubject
    {
        private Dictionary<Share, List<IObserver>> stock;
        private Logger logger;
        public StockExchange()
        {
            stock = new Dictionary<Share, List<IObserver>>();
            logger = Logger.GetLogger();
        }
        public void AddShare(Share share)
        {
            stock[share] = new List<IObserver>();
        }
        public async void UpdateStock(Share share, double price)
        {
            if (price > 0)
            {
                share.Price = price;
                logger.Log($"The '{share.Name}' share price changed to {price}.");
                await NotifyObserverAsync(share);
            }
            else
            {
                Console.WriteLine("Cannot do action. Wrong price.");
            }
        }
        public void RegisterObserver(IObserver observer, Share share)
        {
            logger.Log($"Observer {observer.Name} subscribed to '{share.Name}' shares.");
            stock[share].Add(observer);
        }
        public void UnegisterObserver(IObserver observer, Share share)
        {
            if (stock[share].Remove(observer))
            {
                logger.Log($"Observer {observer.Name} unsubscribed from '{share.Name}' shares.");
                Console.WriteLine("Observer unregistered");
            }
            else Console.WriteLine("Cannot do action. Observer is not registered.");
        }
        public async Task NotifyObserverAsync(Share share)
        {
            foreach (IObserver observer in stock[share])
            {
                await observer.UpdateAsync(share.Name, share.Price);
            }
        }
    }
}
