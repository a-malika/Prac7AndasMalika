using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class BusCostCalculationStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(int countOfPassengers, double distance, bool hasADiscount, string classOfService)
        {
            double cost = distance * 10.9;
            if (hasADiscount) cost = 0;
            return cost * countOfPassengers;
        }
    }
}

