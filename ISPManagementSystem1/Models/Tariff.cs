using System;

namespace ISPManagementSystem1.Models
{
    public class Tariff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SpeedMbps { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // Конструктор за замовчуванням
        public Tariff()
        {
            IsActive = true;
        }

        // Конструктор з параметрами
        public Tariff(string name, decimal price, int speedMbps, string description)
        {
            Name = name;
            Price = price;
            SpeedMbps = speedMbps;
            Description = description;
            IsActive = true;
        }

        // Перевизначення методу ToString() для зручного відображення
        public override string ToString()
        {
            return $"{Name} ({SpeedMbps} Мбіт/с, {Price} грн)";
        }
    }
}