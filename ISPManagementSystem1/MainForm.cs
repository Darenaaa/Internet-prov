using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISPManagementSystem1.Data;
using ISPManagementSystem1.Models;

namespace ISPManagementSystem1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += Form1_Load;  // Додайте цей рядок
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Створюємо/перевіряємо базу даних при запуску програми
                DatabaseManager.CreateDatabase();

                // Відображаємо повідомлення про успішну ініціалізацію
                MessageBox.Show("База даних успішно ініціалізована", "Інформація",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при ініціалізації бази даних: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Створюємо/перевіряємо базу даних при запуску програми
                DatabaseManager.CreateDatabase();

                // Оновлюємо статистику
                UpdateStatistics();

                // Відображаємо повідомлення про успішну ініціалізацію
                MessageBox.Show("База даних успішно ініціалізована", "Інформація",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при ініціалізації бази даних: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void UpdateStatistics()
        {
            try
            {
                // Оновлюємо статистику на формі
                labelClientsCount.Text = DatabaseManager.GetClientsCount().ToString();
                labelConnectionsCount.Text = DatabaseManager.GetActiveConnectionsCount().ToString();
                labelTicketsCount.Text = DatabaseManager.GetOpenTicketsCount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при оновленні статистики: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            ClientForm clientForm = new ClientForm();
            if (clientForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Клієнт успішно доданий", "Інформація",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatistics();
            }
        }

        private void btnQuickPayment_Click(object sender, EventArgs e)
        {
            try
            {
                // Перевіряємо, чи є клієнти в базі даних
                List<Client> clients = DatabaseManager.GetAllClients();
                if (clients.Count == 0)
                {
                    MessageBox.Show("Немає жодного клієнта в базі даних. Спочатку додайте клієнта.",
                        "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Відкриваємо форму для швидкого платежу
                QuickPaymentForm paymentForm = new QuickPaymentForm();
                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    // Якщо необхідно оновити статистику на головній формі
                    UpdateStatistics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи є клієнти в базі даних
            List<Client> clients = DatabaseManager.GetAllClients();
            if (clients.Count == 0)
            {
                MessageBox.Show("Немає жодного клієнта в базі даних. Спочатку додайте клієнта.",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
        }

        private void viewClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();
            clientsForm.ShowDialog();
            UpdateStatistics();
        }

        private void viewTariffsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TariffsForm tariffsForm = new TariffsForm();
            tariffsForm.ShowDialog();
            UpdateStatistics();
        }


        private void clientReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи є клієнти в базі даних
            List<Client> clients = DatabaseManager.GetAllClients();
            if (clients.Count == 0)
            {
                MessageBox.Show("Немає жодного клієнта в базі даних. Звіт неможливо сформувати.",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void tariffReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи є тарифи в базі даних
            List<Tariff> tariffs = DatabaseManager.GetAllTariffs();
            if (tariffs.Count == 0)
            {
                MessageBox.Show("Немає жодного тарифу в базі даних. Звіт неможливо сформувати.",
                    "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
        }

       

        private void financialReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи є платежі в базі даних
            // Це спрощена перевірка, можна удосконалити
            using (SqlConnection connection = new SqlConnection(DatabaseManager.connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Payments";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show("Немає жодного платежу в базі даних. Звіт неможливо сформувати.",
                            "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            
        }
    }
}
