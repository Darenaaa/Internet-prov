using System;

namespace ISPManagementSystem1.Models
{
    public class Connection
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TariffId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        public bool IsActive { get; set; }

        // Конструктор за замовчуванням
        public Connection()
        {
            StartDate = DateTime.Now;
            IsActive = true;
        }

        // Конструктор з параметрами
        public Connection(int clientId, int tariffId, string ipAddress, string macAddress)
        {
            ClientId = clientId;
            TariffId = tariffId;
            IPAddress = ipAddress;
            MACAddress = macAddress;
            StartDate = DateTime.Now;
            IsActive = true;
        }
    }
}
