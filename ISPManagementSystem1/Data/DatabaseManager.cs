using ISPManagementSystem1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ISPManagementSystem1.Data
{
    public static class DatabaseManager
    {
        // Рядок підключення до бази даних
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ISPDatabase;Integrated Security=True";

        public static DataTable GetConnectionsWithDetails(int? clientId = null, int? tariffId = null)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Базовий запит
                string query = @"
            SELECT 
                c.Id, 
                cl.FullName AS ClientName, 
                t.Name AS TariffName,
                t.Price AS MonthlyPrice,
                t.SpeedMbps AS Speed,
                c.StartDate, 
                c.EndDate, 
                c.IPAddress, 
                c.MACAddress, 
                c.IsActive,
                c.ClientId,
                c.TariffId
            FROM Connections c
            INNER JOIN Clients cl ON c.ClientId = cl.Id
            INNER JOIN Tariffs t ON c.TariffId = t.Id
            WHERE 1=1";  // 1=1 дозволяє легко додавати умови WHERE

                // Додаємо фільтри, якщо вони задані
                if (clientId.HasValue && clientId.Value > 0)
                {
                    query += " AND c.ClientId = @ClientId";
                }

                if (tariffId.HasValue && tariffId.Value > 0)
                {
                    query += " AND c.TariffId = @TariffId";
                }

                // Додаємо сортування
                query += " ORDER BY c.IsActive DESC, cl.FullName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Додаємо параметри, якщо вони задані
                    if (clientId.HasValue && clientId.Value > 0)
                    {
                        command.Parameters.AddWithValue("@ClientId", clientId.Value);
                    }

                    if (tariffId.HasValue && tariffId.Value > 0)
                    {
                        command.Parameters.AddWithValue("@TariffId", tariffId.Value);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
        // Метод для створення бази даних та таблиць
        public static void CreateDatabase()
        {
            try
            {
                // Спочатку переконаємося, що база даних існує
                EnsureDatabaseExists();

                // Використовуємо підключення до існуючої бази даних
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Створюємо таблицю клієнтів
                    ExecuteNonQuery(connection, CreateClientsTableScript());

                    // Створюємо таблицю тарифів
                    ExecuteNonQuery(connection, CreateTariffsTableScript());

                    // Створюємо таблицю підключень
                    ExecuteNonQuery(connection, CreateConnectionsTableScript());

                    // Створюємо таблицю платежів
                    ExecuteNonQuery(connection, CreatePaymentsTableScript());

                    // Створюємо таблицю заявок на техпідтримку
                    ExecuteNonQuery(connection, CreateSupportTicketsTableScript());

                    // Опціонально: Додаємо тестові дані
                    InsertTestData(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при створенні бази даних: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Метод для виконання SQL-запитів
        private static void ExecuteNonQuery(SqlConnection connection, string commandText)
        {
            using (SqlCommand command = new SqlCommand(commandText, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        // Метод для перевірки існування бази даних
        private static void EnsureDatabaseExists()
        {
            // Рядок підключення до master бази даних
            string masterConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(masterConnectionString))
            {
                connection.Open();

                // Перевіряємо, чи існує база даних
                string checkDatabaseExists = @"
                    IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ISPDatabase')
                    BEGIN
                        CREATE DATABASE ISPDatabase;
                    END";

                using (SqlCommand command = new SqlCommand(checkDatabaseExists, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Методи, що повертають SQL-скрипти для створення таблиць

        private static string CreateClientsTableScript()
        {
            return @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Clients' AND xtype='U')
                CREATE TABLE Clients (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    FullName NVARCHAR(100) NOT NULL,
                    Address NVARCHAR(200) NOT NULL,
                    Phone NVARCHAR(20) NOT NULL,
                    Email NVARCHAR(100),
                    RegistrationDate DATETIME NOT NULL,
                    IsActive BIT NOT NULL
                )";
        }

        private static string CreateTariffsTableScript()
        {
            return @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Tariffs' AND xtype='U')
                CREATE TABLE Tariffs (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(50) NOT NULL,
                    Price DECIMAL(10,2) NOT NULL,
                    SpeedMbps INT NOT NULL,
                    Description NVARCHAR(500),
                    IsActive BIT NOT NULL
                )";
        }

        private static string CreateConnectionsTableScript()
        {
            return @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Connections' AND xtype='U')
                CREATE TABLE Connections (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    ClientId INT NOT NULL,
                    TariffId INT NOT NULL,
                    StartDate DATETIME NOT NULL,
                    EndDate DATETIME,
                    IPAddress NVARCHAR(20),
                    MACAddress NVARCHAR(20),
                    IsActive BIT NOT NULL,
                    FOREIGN KEY (ClientId) REFERENCES Clients(Id),
                    FOREIGN KEY (TariffId) REFERENCES Tariffs(Id)
                )";
        }

        private static string CreatePaymentsTableScript()
        {
            return @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Payments' AND xtype='U')
                CREATE TABLE Payments (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    ClientId INT NOT NULL,
                    Amount DECIMAL(10,2) NOT NULL,
                    PaymentDate DATETIME NOT NULL,
                    PaymentMethod NVARCHAR(50) NOT NULL,
                    Description NVARCHAR(200),
                    FOREIGN KEY (ClientId) REFERENCES Clients(Id)
                )";
        }

        private static string CreateSupportTicketsTableScript()
        {
            return @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SupportTickets' AND xtype='U')
                CREATE TABLE SupportTickets (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    ClientId INT NOT NULL,
                    Title NVARCHAR(100) NOT NULL,
                    Description NVARCHAR(1000) NOT NULL,
                    CreationDate DATETIME NOT NULL,
                    ResolutionDate DATETIME,
                    Status NVARCHAR(20) NOT NULL,
                    Priority NVARCHAR(20) NOT NULL,
                    AssignedToEmployeeId INT,
                    FOREIGN KEY (ClientId) REFERENCES Clients(Id)
                )";
        }

        // Метод для додавання тестових даних
        private static void InsertTestData(SqlConnection connection)
        {
            // Перевіряємо, чи є вже клієнти в базі
            string checkClientsExist = "SELECT COUNT(*) FROM Clients";
            using (SqlCommand command = new SqlCommand(checkClientsExist, connection))
            {
                int clientCount = (int)command.ExecuteScalar();
                if (clientCount > 0)
                    return; // Якщо дані вже є, не додаємо тестові
            }

            // Додаємо тестових клієнтів
            string insertClients = @"
                INSERT INTO Clients (FullName, Address, Phone, Email, RegistrationDate, IsActive)
                VALUES 
                ('Іванов Іван Іванович', 'м. Київ, вул. Хрещатик, 1', '+380991234567', 'ivanov@example.com', GETDATE(), 1),
                ('Петров Петро Петрович', 'м. Львів, вул. Франка, 15', '+380992345678', 'petrov@example.com', GETDATE(), 1),
                ('Сидоренко Олена Миколаївна', 'м. Одеса, вул. Дерибасівська, 7', '+380993456789', 'sydorenko@example.com', GETDATE(), 1)";

            ExecuteNonQuery(connection, insertClients);

            // Додаємо тестові тарифи
            string insertTariffs = @"
                INSERT INTO Tariffs (Name, Price, SpeedMbps, Description, IsActive)
                VALUES 
                ('Базовий', 150.00, 50, 'Базовий тарифний план зі швидкістю 50 Мбіт/с', 1),
                ('Стандарт', 250.00, 100, 'Стандартний тарифний план зі швидкістю 100 Мбіт/с', 1),
                ('Преміум', 350.00, 1000, 'Преміум тарифний план зі швидкістю 1 Гбіт/с', 1)";

            ExecuteNonQuery(connection, insertTariffs);

            // Додаємо тестові підключення
            string insertConnections = @"
                INSERT INTO Connections (ClientId, TariffId, StartDate, IPAddress, MACAddress, IsActive)
                VALUES 
                (1, 1, GETDATE(), '192.168.1.100', 'AA:BB:CC:DD:EE:FF', 1),
                (2, 2, GETDATE(), '192.168.1.101', 'AA:BB:CC:DD:EE:11', 1),
                (3, 3, GETDATE(), '192.168.1.102', 'AA:BB:CC:DD:EE:22', 1)";

            ExecuteNonQuery(connection, insertConnections);

            // Додаємо тестові платежі
            string insertPayments = @"
                INSERT INTO Payments (ClientId, Amount, PaymentDate, PaymentMethod, Description)
                VALUES 
                (1, 150.00, GETDATE(), 'Готівка', 'Оплата за послуги інтернет'),
                (2, 250.00, GETDATE(), 'Картка', 'Оплата за послуги інтернет'),
                (3, 350.00, GETDATE(), 'Онлайн-платіж', 'Оплата за послуги інтернет')";

            ExecuteNonQuery(connection, insertPayments);

            // Додаємо тестові заявки на техпідтримку
            string insertTickets = @"
                INSERT INTO SupportTickets (ClientId, Title, Description, CreationDate, Status, Priority)
                VALUES 
                (1, 'Проблема з підключенням', 'Відсутній інтернет з 10:00', GETDATE(), 'Відкрито', 'Високий'),
                (2, 'Низька швидкість', 'Швидкість нижча, ніж за тарифом', GETDATE(), 'В роботі', 'Середній'),
                (3, 'Питання по рахунку', 'Потрібна консультація по рахунку', GETDATE(), 'Відкрито', 'Низький')";

            ExecuteNonQuery(connection, insertTickets);
        }
        public static void AddClient(Client client)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Clients (FullName, Address, Phone, Email, RegistrationDate, IsActive) 
                        VALUES (@FullName, @Address, @Phone, @Email, @RegistrationDate, @IsActive)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", client.FullName);
                    command.Parameters.AddWithValue("@Address", client.Address);
                    command.Parameters.AddWithValue("@Phone", client.Phone);
                    command.Parameters.AddWithValue("@Email", client.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RegistrationDate", client.RegistrationDate);
                    command.Parameters.AddWithValue("@IsActive", client.IsActive);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateClient(Client client)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE Clients SET FullName = @FullName, Address = @Address, 
                        Phone = @Phone, Email = @Email, IsActive = @IsActive 
                        WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", client.Id);
                    command.Parameters.AddWithValue("@FullName", client.FullName);
                    command.Parameters.AddWithValue("@Address", client.Address);
                    command.Parameters.AddWithValue("@Phone", client.Phone);
                    command.Parameters.AddWithValue("@Email", client.Email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", client.IsActive);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Clients";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new Client
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FullName = reader["FullName"].ToString(),
                                Address = reader["Address"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            });
                        }
                    }
                }
            }

            return clients;
        }

        // Методи для отримання статистики
        public static int GetClientsCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Clients WHERE IsActive = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static int GetActiveConnectionsCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Connections WHERE IsActive = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static int GetOpenTicketsCount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM SupportTickets WHERE Status IN ('Відкрито', 'В роботі')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public static void DeleteClient(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Перевіряємо наявність пов'язаних записів у таблиці Connections
                string checkConnectionsQuery = "SELECT COUNT(*) FROM Connections WHERE ClientId = @ClientId";
                bool hasConnections = false;

                using (SqlCommand command = new SqlCommand(checkConnectionsQuery, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    int connectionsCount = (int)command.ExecuteScalar();
                    hasConnections = connectionsCount > 0;
                }

                // Перевіряємо наявність пов'язаних записів у таблиці Payments
                string checkPaymentsQuery = "SELECT COUNT(*) FROM Payments WHERE ClientId = @ClientId";
                bool hasPayments = false;

                using (SqlCommand command = new SqlCommand(checkPaymentsQuery, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    int paymentsCount = (int)command.ExecuteScalar();
                    hasPayments = paymentsCount > 0;
                }

                // Перевіряємо наявність пов'язаних записів у таблиці SupportTickets
                string checkTicketsQuery = "SELECT COUNT(*) FROM SupportTickets WHERE ClientId = @ClientId";
                bool hasTickets = false;

                using (SqlCommand command = new SqlCommand(checkTicketsQuery, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    int ticketsCount = (int)command.ExecuteScalar();
                    hasTickets = ticketsCount > 0;
                }

                // Якщо є пов'язані записи, запитуємо підтвердження
                if (hasConnections || hasPayments || hasTickets)
                {
                    DialogResult result = MessageBox.Show(
                        "Цей клієнт має пов'язані записи (підключення, платежі або заявки). " +
                        "Видалення клієнта призведе до видалення всіх пов'язаних записів. Продовжити?",
                        "Підтвердження видалення",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result != DialogResult.Yes)
                    {
                        return; // Користувач відмовився від видалення
                    }

                    // Видаляємо пов'язані записи
                    if (hasConnections)
                    {
                        string deleteConnectionsQuery = "DELETE FROM Connections WHERE ClientId = @ClientId";
                        using (SqlCommand command = new SqlCommand(deleteConnectionsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ClientId", clientId);
                            command.ExecuteNonQuery();
                        }
                    }

                    if (hasPayments)
                    {
                        string deletePaymentsQuery = "DELETE FROM Payments WHERE ClientId = @ClientId";
                        using (SqlCommand command = new SqlCommand(deletePaymentsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ClientId", clientId);
                            command.ExecuteNonQuery();
                        }
                    }

                    if (hasTickets)
                    {
                        string deleteTicketsQuery = "DELETE FROM SupportTickets WHERE ClientId = @ClientId";
                        using (SqlCommand command = new SqlCommand(deleteTicketsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ClientId", clientId);
                            command.ExecuteNonQuery();
                        }
                    }
                }

                // Видаляємо самого клієнта
                string deleteClientQuery = "DELETE FROM Clients WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(deleteClientQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", clientId);
                    command.ExecuteNonQuery();
                }
            }
        }
        

        // Отримання всіх тарифів
        public static List<Tariff> GetAllTariffs()
        {
            List<Tariff> tariffs = new List<Tariff>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Tariffs";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tariffs.Add(new Tariff
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                SpeedMbps = Convert.ToInt32(reader["SpeedMbps"]),
                                Description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : null,
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            });
                        }
                    }
                }
            }

            return tariffs;
        }

        // Додавання нового тарифу
        public static void AddTariff(Tariff tariff)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Tariffs (Name, Price, SpeedMbps, Description, IsActive) 
                        VALUES (@Name, @Price, @SpeedMbps, @Description, @IsActive)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", tariff.Name);
                    command.Parameters.AddWithValue("@Price", tariff.Price);
                    command.Parameters.AddWithValue("@SpeedMbps", tariff.SpeedMbps);
                    command.Parameters.AddWithValue("@Description", tariff.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", tariff.IsActive);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Оновлення існуючого тарифу
        public static void UpdateTariff(Tariff tariff)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"UPDATE Tariffs SET Name = @Name, Price = @Price, 
                        SpeedMbps = @SpeedMbps, Description = @Description, 
                        IsActive = @IsActive WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", tariff.Id);
                    command.Parameters.AddWithValue("@Name", tariff.Name);
                    command.Parameters.AddWithValue("@Price", tariff.Price);
                    command.Parameters.AddWithValue("@SpeedMbps", tariff.SpeedMbps);
                    command.Parameters.AddWithValue("@Description", tariff.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", tariff.IsActive);

                    command.ExecuteNonQuery();
                }
            }
        }

        // Видалення тарифу
        public static void DeleteTariff(int tariffId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Перевіряємо наявність пов'язаних записів у таблиці Connections
                string checkConnectionsQuery = "SELECT COUNT(*) FROM Connections WHERE TariffId = @TariffId";
                bool hasConnections = false;

                using (SqlCommand command = new SqlCommand(checkConnectionsQuery, connection))
                {
                    command.Parameters.AddWithValue("@TariffId", tariffId);
                    int connectionsCount = (int)command.ExecuteScalar();
                    hasConnections = connectionsCount > 0;
                }

                // Якщо є пов'язані записи, запитуємо підтвердження
                if (hasConnections)
                {
                    DialogResult result = MessageBox.Show(
                        "Цей тариф використовується в підключеннях. Видалення тарифу призведе до видалення всіх пов'язаних підключень. Продовжити?",
                        "Підтвердження видалення",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result != DialogResult.Yes)
                    {
                        return; // Користувач відмовився від видалення
                    }

                    // Видаляємо пов'язані підключення
                    string deleteConnectionsQuery = "DELETE FROM Connections WHERE TariffId = @TariffId";
                    using (SqlCommand command = new SqlCommand(deleteConnectionsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TariffId", tariffId);
                        command.ExecuteNonQuery();
                    }
                }

                // Видаляємо сам тариф
                string deleteTariffQuery = "DELETE FROM Tariffs WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(deleteTariffQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", tariffId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public static Connection GetConnectionById(int connectionId)
        {
            Connection connection = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Connections WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Id", connectionId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            connection = new Connection
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ClientId = Convert.ToInt32(reader["ClientId"]),
                                TariffId = Convert.ToInt32(reader["TariffId"]),
                                StartDate = Convert.ToDateTime(reader["StartDate"]),
                                EndDate = reader["EndDate"] != DBNull.Value
                                    ? (DateTime?)Convert.ToDateTime(reader["EndDate"])
                                    : null,
                                IPAddress = reader["IPAddress"] != DBNull.Value ? reader["IPAddress"].ToString() : null,
                                MACAddress = reader["MACAddress"] != DBNull.Value ? reader["MACAddress"].ToString() : null,
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }

            return connection;
        }
    }
   
    
    
}
