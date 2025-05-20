using System;

namespace ISPManagementSystem1.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }

        // Конструктор за замовчуванням
        public Client()
        {
            RegistrationDate = DateTime.Now;
            IsActive = true;
        }

        // Конструктор з параметрами
        public Client(string fullName, string address, string phone, string email)
        {
            FullName = fullName;
            Address = address;
            Phone = phone;
            Email = email;
            RegistrationDate = DateTime.Now;
            IsActive = true;
        }

        // Перевизначення методу ToString() для зручного відображення
        public override string ToString()
        {
            return FullName;
        }
    }
}
