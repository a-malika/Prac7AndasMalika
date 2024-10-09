using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public class TravelBookingContext
    {
        private ICostCalculationStrategy costCalculationStrategy;
        public TravelBookingContext(ICostCalculationStrategy costCalculationStrategy)
        {
            this.costCalculationStrategy = costCalculationStrategy;
        }
        public void SetPaymentMethod(ICostCalculationStrategy costCalculationStrategy)
        {
            this.costCalculationStrategy = costCalculationStrategy;
        }
        public double CalculateCost(int countOfPassengers, double distance, bool hasADiscount, string classOfService)
        {
            return costCalculationStrategy.CalculateCost(countOfPassengers, distance, hasADiscount, classOfService);
        }
    }
}
