using System;

namespace SimpleFactoryPattern
{
    
    public class VisitOptions
    {
        public decimal PricePerHour { get; set; }

        public VisitOptions(decimal pricePerHour)
        {
            PricePerHour = pricePerHour;
        }
    }

    public class CompanyVisitOptions : VisitOptions
    {
        public CompanyVisitOptions(decimal pricePerHour, decimal companyDiscountPercentage) : base(pricePerHour)
        {
            CompanyDiscountPercentage = companyDiscountPercentage;
        }

        public decimal CompanyDiscountPercentage { get; set; }

    }


    // Fabryka
    public class VisitFactory
    {
        // Product
        public ICalculateCostStrategy Create(string kind) => kind switch
        {
            "N" => new NfzCalculateCostStrategy(),
            "P" => new PrivateCalculateCostStrategy(new VisitOptions(100)),
            "F" => new CompanyCalculateCostStrategy(new CompanyVisitOptions(100, 0.9m)),
            "T" => throw new NotImplementedException(),
            _ => throw new NotSupportedException($"{kind} not supported."),
        };
    }

    public class VisitFactoryDictionary
    {
        private IDictionary<string, ICalculateCostStrategy> strategies = new  Dictionary<string, ICalculateCostStrategy>();

        public void Register(string kind, ICalculateCostStrategy strategy)
        {
            strategies[kind] = strategy;
        }
        public ICalculateCostStrategy Create(string kind) => strategies[kind];

    }



    public class Visit
    {
        public DateTime DateVisit { get; set; }

        private ICalculateCostStrategy calculateCostStrategy;

        public void SetStrategy(ICalculateCostStrategy calculateCostStrategy)
        {
            this.calculateCostStrategy = calculateCostStrategy;
        }

        public decimal CalculateCost(TimeSpan duration)
        {
            var cost = calculateCostStrategy.CalculateCost(duration);

            return cost;
        }
    }



    public interface IVisit
    {
      
    }


    public interface ICalculateCostStrategy
    {
        decimal CalculateCost(TimeSpan duration);
    }

    public class NfzCalculateCostStrategy : ICalculateCostStrategy
    {
        public decimal CalculateCost(TimeSpan duration)
        {
            return 0;
        }
    }

    public class PrivateCalculateCostStrategy : ICalculateCostStrategy
    {
        public VisitOptions Options { get; set; }

        public PrivateCalculateCostStrategy(VisitOptions options)
        {
            Options = options;
        }

        public decimal CalculateCost(TimeSpan duration)
        {
            decimal cost;

            cost = (decimal)duration.TotalHours * Options.PricePerHour;

            return cost;
        }
    }

    public class CompanyCalculateCostStrategy : ICalculateCostStrategy
    {
        public CompanyVisitOptions Options { get; set; }        

        public CompanyCalculateCostStrategy(CompanyVisitOptions options)
        {
            Options = options;
        }

        public decimal CalculateCost(TimeSpan duration)
        {
            decimal cost = 0;

            cost = (decimal)duration.TotalHours * Options.PricePerHour * Options.CompanyDiscountPercentage;

            return cost;
        }
    }
}
