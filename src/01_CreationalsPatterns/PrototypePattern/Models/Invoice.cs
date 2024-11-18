using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace PrototypePattern
{
    public class Bill : ICloneable
    {
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public Customer Customer { get; set; }
        public List<BillItem> Items { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone(); // (Shallow Copy) Płytka Kopia
        }
    }
    
    // Deep Copy (Głębokia Kopia)
    // https://github.com/AlenToma/FastDeepCloner
    public class BillItem
    {
        public string Title { get; set; }
        public  decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Invoice : ICloneable
    {
        public Invoice(string number, DateTime createDate, Customer customer)
        {
            Number = number;
            CreateDate = createDate;
            Customer = customer;
            PaymentStatus = PaymentStatus.Awaiting;
        }

        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public Customer Customer { get; set; }

        public PaymentStatus PaymentStatus { get; private set; }
         
        public decimal TotalAmount => Details.Sum(d => d.Quantity * d.Amount);

        public IList<InvoiceDetail> Details { get; set; } = new List<InvoiceDetail>();

        public void Paid(decimal amount)
        {
            if (amount >= TotalAmount)
            {                
                PaymentStatus = PaymentStatus.Paid;
            }
        }

        public override string ToString()
        {
            return $"Invoice No {Number} {TotalAmount:C2} {Customer.FullName}";
        }

        public object Clone()
        {
            Invoice copyInvoice = new Invoice(this.Number, DateTime.Today, this.Customer);

            foreach (InvoiceDetail detail in Details)
            {
                copyInvoice.Details.Add((InvoiceDetail)detail.Clone());
            }

            copyInvoice.Paid(TotalAmount);

            return copyInvoice;
        }

        public Invoice CloneAsInvoice()
        {
           return (Invoice) this.Clone();
        }
    }

    public enum PaymentStatus
    {
        Awaiting,
        Paid,        
    }

   


}
