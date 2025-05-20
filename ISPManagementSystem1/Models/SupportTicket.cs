using System;

namespace ISPManagementSystem1.Models
{
    public class SupportTicket
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public string Status { get; set; } // Відкрито, В роботі, Вирішено, Закрито
        public string Priority { get; set; } // Низький, Середній, Високий, Критичний
        public int? AssignedToEmployeeId { get; set; }

        // Конструктор за замовчуванням
        public SupportTicket()
        {
            CreationDate = DateTime.Now;
            Status = "Відкрито";
            Priority = "Середній";
        }

        // Конструктор з параметрами
        public SupportTicket(int clientId, string title, string description, string priority)
        {
            ClientId = clientId;
            Title = title;
            Description = description;
            Priority = priority;
            CreationDate = DateTime.Now;
            Status = "Відкрито";
        }
    }
}