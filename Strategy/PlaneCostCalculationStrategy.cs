using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class PlaneCostCalculationStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(int countOfPassengers, double distance, bool hasADiscount, string classOfService)
        {
            double cost = distance * 30.1;
            if (classOfService == "Bussiness") cost *= 1.5;
            if (hasADiscount) cost *= 0.8;
            return cost* countOfPassengers;
        }
    }
}
