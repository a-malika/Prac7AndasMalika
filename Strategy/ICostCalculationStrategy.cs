using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public interface ICostCalculationStrategy
    {
        double CalculateCost(int countOfPassengers, double distance, bool hasADiscount, string classOfService);
    }
}
