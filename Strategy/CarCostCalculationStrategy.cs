using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class CarCostCalculationStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(int countOfPassengers, double distance, bool hasADiscount, string classOfService)
        {
            double cost = distance * 18;
            if (classOfService == "Bussiness") cost += 500;
            if (hasADiscount) cost *= 0.9;
            return cost * countOfPassengers;
        }
    }
}
