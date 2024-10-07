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
            TravelBookingContext context = null;
            Console.WriteLine("What type of transport do you choose? (1 - car, 2 - bus, 3 - train, 4 - plane)");
            int userAns = Convert.ToInt32(Console.ReadLine());
            switch (userAns)
            {
                case 1:
                    context = new TravelBookingContext(new CarCostCalculationStrategy());
                    break;
                case 2:
                    context = new TravelBookingContext(new BusCostCalculationStrategy());
                    break;
                case 3:
                    context = new TravelBookingContext(new TrainCostCalculationStrategy());
                    break;
                case 4:
                    context = new TravelBookingContext(new PlaneCostCalculationStrategy());
                    break;
                default:
                    throw new Exception("Unsupported type of transport");
            }
            Console.WriteLine("Count Of Passengers: ");
            int cnt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Distance: ");
            double dt = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Has A Discoutn: ");
            bool dc = true ? Console.ReadLine().ToLower() == "yes" : false;
            Console.WriteLine("Class Of Service: ");
            string cl = Console.ReadLine();

            var result = context.CalculateCost(cnt, dt, dc, cl);
            Console.WriteLine("Result cost: {0}", result);
        }
    }
}
