using System;

namespace SimpleFactoryPattern
{
    // Fabryka
    public class VisitFactory
    {
        // Product
        public IVisit Create(string kind, TimeSpan duration, decimal pricePerHour)
        {
            if (kind == "N")
            {
                return new NfZVisit();
            }
            else if (kind == "P")
            {
                return new PrivateVisit(duration, pricePerHour);

            }
            else if (kind == "F")
            {
                return new CompanyVisit(duration, pricePerHour);
            }
            else if (kind == "T")
            {
                return new TeleVisit();
            }
            else
            {
                throw new NotSupportedException($"{kind} not supported.");
            }


        }
    }


    public class NfZVisit : IVisit
    {
        public decimal CalculateCost()
        {
            return 0;
        }
    }

    public class PrivateVisit : IVisit
    {
        public TimeSpan Duration { get; set; }
        public decimal PricePerHour { get; set; }

        public PrivateVisit(TimeSpan duration, decimal pricePerHour)
        {
            Duration = duration;
            PricePerHour = pricePerHour;
        }

        public decimal CalculateCost()
        {
            decimal cost;

            cost = (decimal)Duration.TotalHours * PricePerHour;

            return cost;

        }

    }

    public class CompanyVisit : IVisit
    {
        public TimeSpan Duration { get; set; }
        public decimal PricePerHour { get; set; }

        private const decimal companyDiscountPercentage = 0.9m;

        public CompanyVisit(TimeSpan duration, decimal pricePerHour)
        {
            Duration = duration;
            PricePerHour = pricePerHour;
        }

        public decimal CalculateCost()
        {
            decimal cost = 0;

            cost = (decimal)Duration.TotalHours * PricePerHour * companyDiscountPercentage;

            return cost;
        }
    }

    public class TeleVisit : IVisit
    {
        public decimal CalculateCost()
        {
            return 5m;
        }
    }

    public interface IVisit
    {
        decimal CalculateCost();
    }
}
