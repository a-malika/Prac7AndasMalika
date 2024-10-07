using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class TrainCostCalculationStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(int countOfPassengers, double distance, bool hasADiscount, string classOfService)
        {
            double cost = distance * 12.5;
            if (classOfService == "Bussiness") cost *= 3;
            if (hasADiscount) cost *= 0.8;
            return cost * countOfPassengers;
        }
    }
}
