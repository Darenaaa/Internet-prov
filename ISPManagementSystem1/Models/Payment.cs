using System;

namespace ISPManagementSystem1.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Description { get; set; }

        // Конструктор за замовчуванням
        public Payment()
        {
            PaymentDate = DateTime.Now;
        }

        // Конструктор з параметрами
        public Payment(int clientId, decimal amount, string paymentMethod, string description)
        {
            ClientId = clientId;
            Amount = amount;
            PaymentMethod = paymentMethod;
            Description = description;
            PaymentDate = DateTime.Now;
        }
    }
}