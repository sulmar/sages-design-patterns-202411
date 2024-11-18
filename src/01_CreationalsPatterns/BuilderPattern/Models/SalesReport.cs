using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPattern
{
    public class SalesReportBuilder
    {
        private SalesReport salesReport = new SalesReport();

        private IEnumerable<Order> orders;

        public void AddOrders(IEnumerable<Order> orders)
        {
            this.orders = orders;
        }

        public void AddHeader(string title)
        {
            salesReport.Title = title;
            salesReport.CreateDate = DateTime.Now;
            salesReport.TotalSalesAmount = orders.Sum(s => s.Amount);
        }

        public void AddContent()
        {
            salesReport.ProductDetails = orders
               .SelectMany(o => o.Details)
               .GroupBy(o => o.Product)
               .Select(g => new ProductReportDetail(g.Key, g.Sum(p => p.Quantity), g.Sum(p => p.LineTotal)));
        }

        public void AddFooter()
        {

        }

        public SalesReport Build()
        {
            return salesReport;
        }

    public class SalesReport
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalSalesAmount { get; set; }

        public IEnumerable<ProductReportDetail> ProductDetails { get; set; }
        public IEnumerable<GenderReportDetail> GenderDetails { get; set; }


        public override string ToString()
        {
            string output = string.Empty;

            output += "------------------------------\n";

            output += $"{Title} {CreateDate}\n";
            output += $"Total Sales Amount: {TotalSalesAmount:c2}\n";

            output += "------------------------------\n";

            output += "Total By Products:\n";
            foreach (var detail in ProductDetails)
            {
                output += $"- {detail.Product.Name} {detail.Quantity} {detail.TotalAmount:c2}\n";
            }
            output += "Total By Gender:\n";
            foreach (var detail in GenderDetails)
            {
                output += $"- {detail.Gender} {detail.Quantity} {detail.TotalAmount:c2}\n";
            }

            return output;
        }
    }




}