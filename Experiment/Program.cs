using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7
{
    public interface ITRavelProperty
    {
        int Passenger { get; set; }
        ServiceClass ServiceClass { get; set; }
        bool HasDiscount { get; set; }
        bool HasBaggage { get; set; }
    }
    public class TravelProperty : ITRavelProperty
    {
        public int Passenger { get; set; }
        public ServiceClass ServiceClass { get; set; }
        public bool HasDiscount { get; set; }
        public bool HasBaggage { get; set; }
    }
    public interface IStrategyBuilder
    {
        void SetPassengers();
        void SetServiceClass();
        void SetHavingDiscount();
        void SetHavingBaggage();
        decimal GetTravelCost();
        TravelProperty GetStrategy();
    }
    public class StandartStrategy : IStrategyBuilder
    {
        private TravelProperty travelProperty = new TravelProperty();
        public void SetPassengers()
        {
            travelProperty.Passenger = 1;
        }
        public void SetServiceClass()
        {
            travelProperty.ServiceClass = ServiceClass.Econom;
        }
        public void SetHavingDiscount()
        {
            travelProperty.HasDiscount = false;
        }
        public void SetHavingBaggage()
        {
            travelProperty.HasBaggage = true;
        }

        public decimal GetTravelCost()
        {
            decimal cost = 0;
            switch (travelProperty.ServiceClass)
            {
                case ServiceClass.Econom:
                    cost = 300 * travelProperty.Passenger;
                    break;
                case ServiceClass.Bussiness:
                    cost = 700 * travelProperty.Passenger;
                    break;
            }
            if (travelProperty.HasDiscount) cost = cost / 10 * 9;
            if (travelProperty.HasBaggage) cost += 50;
            return cost;
        }
        public TravelProperty GetStrategy()
        {
            return travelProperty;
        }
    }
    public class FamilyStrategy : IStrategyBuilder
    {
        private TravelProperty travelProperty = new TravelProperty();
        public void SetPassengers()
        {
            travelProperty.Passenger = 4;
        }
        public void SetServiceClass()
        {
            travelProperty.ServiceClass = ServiceClass.Econom;
        }
        public void SetHavingDiscount()
        {
            travelProperty.HasDiscount = true;
        }
        public void SetHavingBaggage()
        {
            travelProperty.HasBaggage = true;
        }

        public decimal GetTravelCost()
        {
            decimal cost = 0;
            switch (travelProperty.ServiceClass)
            {
                case ServiceClass.Econom:
                    cost = 300 * travelProperty.Passenger;
                    break;
                case ServiceClass.Bussiness:
                    cost = 700 * travelProperty.Passenger;
                    break;
            }
            if (travelProperty.HasDiscount) cost = cost / 10 * 8;
            if (travelProperty.HasBaggage) cost += 100;
            return cost;
        }
        public TravelProperty GetStrategy()
        {
            return travelProperty;
        }
    }
    public enum ServiceClass
    {
        Bussiness,
        Econom
    }
    public interface ICostCalculationStrategy
    {
        decimal CalculateCost(IStrategyBuilder strategyBuilder);
    }
    public class AirplaneCost : ICostCalculationStrategy
    {
        public decimal CalculateCost(IStrategyBuilder strategyBuilder)
        {
            strategyBuilder.SetPassengers();
            strategyBuilder.SetServiceClass();
            strategyBuilder.SetHavingBaggage();
            strategyBuilder.SetHavingDiscount();

            return strategyBuilder.GetTravelCost() * 1000;
        }

    }
    public class TrainCost : ICostCalculationStrategy
    {
        public decimal CalculateCost(IStrategyBuilder strategyBuilder)
        {
            strategyBuilder.SetPassengers();
            strategyBuilder.SetServiceClass();
            strategyBuilder.SetHavingBaggage();
            strategyBuilder.SetHavingDiscount();

            return strategyBuilder.GetTravelCost() * 200;
        }
    }
    public class TravelBookingContext
    {
        private ICostCalculationStrategy strategy;
        public TravelBookingContext(ICostCalculationStrategy strategy)
        {
            this.strategy = strategy;
        }
        public void ChangeVehicle(ICostCalculationStrategy strategy)
        {
            this.strategy = strategy;
        }
        public decimal GetTravelCost(IStrategyBuilder strategyBuilder)
        {
            return strategy.CalculateCost(strategyBuilder);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            TravelBookingContext travelBookingContext = new TravelBookingContext(new AirplaneCost());
            var cost = travelBookingContext.GetTravelCost(new StandartStrategy());
            Console.WriteLine($"Standart packet by plane: {cost}");
            cost = travelBookingContext.GetTravelCost(new FamilyStrategy());
            Console.WriteLine($"Family packet by plane: {cost}");

            TravelBookingContext travelBookingContext1 = new TravelBookingContext(new TrainCost());
            cost = travelBookingContext1.GetTravelCost(new StandartStrategy());
            Console.WriteLine($"Standart packet by train: {cost}");
            cost = travelBookingContext1.GetTravelCost(new FamilyStrategy());
            Console.WriteLine($"Family packet by train: {cost}");
        }
    }
}
