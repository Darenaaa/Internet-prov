using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISPManagementSystem1.Models;
using ISPManagementSystem1.Data;
using System.Data.SqlClient;

namespace ISPManagementSystem1
{
    public partial class ClientsForm : Form
    {
        private List<Client> clients;

        public ClientsForm()
        {
            InitializeComponent();
            this.Load += ClientsForm_Load;
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void LoadClients()
        {
            try
            {
                clients = DatabaseManager.GetAllClients();
                dataGridViewClients.DataSource = null;
                dataGridViewClients.DataSource = clients;

                // Налаштування відображення стовпців
                if (dataGridViewClients.Columns.Contains("Id"))
                    dataGridViewClients.Columns["Id"].HeaderText = "ID";
                if (dataGridViewClients.Columns.Contains("FullName"))
                    dataGridViewClients.Columns["FullName"].HeaderText = "ПІБ";
                if (dataGridViewClients.Columns.Contains("Address"))
                    dataGridViewClients.Columns["Address"].HeaderText = "Адреса";
                if (dataGridViewClients.Columns.Contains("Phone"))
                    dataGridViewClients.Columns["Phone"].HeaderText = "Телефон";
                if (dataGridViewClients.Columns.Contains("Email"))
                    dataGridViewClients.Columns["Email"].HeaderText = "Email";
                if (dataGridViewClients.Columns.Contains("RegistrationDate"))
                    dataGridViewClients.Columns["RegistrationDate"].HeaderText = "Дата реєстрації";
                if (dataGridViewClients.Columns.Contains("IsActive"))
                    dataGridViewClients.Columns["IsActive"].HeaderText = "Активний";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні клієнтів: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void DeleteClient(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseManager.connectionString))
            {
                connection.Open();

                // Спочатку перевіримо, чи є у клієнта підключення, платежі або заявки
                bool hasRelatedData = false;

                // Перевірка на підключення
                string checkConnectionsQuery = "SELECT COUNT(*) FROM Connections WHERE ClientId = @ClientId";
                using (SqlCommand command = new SqlCommand(checkConnectionsQuery, connection))
                {
                    command.Parameters.AddWithValue("@ClientId", clientId);
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        hasRelatedData = true;
                    }
                }

                // Перевірка на платежі
                if (!hasRelatedData)
                {
                    string checkPaymentsQuery = "SELECT COUNT(*) FROM Payments WHERE ClientId = @ClientId";
                    using (SqlCommand command = new SqlCommand(checkPaymentsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ClientId", clientId);
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            hasRelatedData = true;
                        }
                    }
                }

                // Перевірка на заявки
                if (!hasRelatedData)
                {
                    string checkTicketsQuery = "SELECT COUNT(*) FROM SupportTickets WHERE ClientId = @ClientId";
                    using (SqlCommand command = new SqlCommand(checkTicketsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ClientId", clientId);
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            hasRelatedData = true;
                        }
                    }
                }

                // Якщо у клієнта є пов'язані дані, запитуємо підтвердження видалення всіх пов'язаних даних
                if (hasRelatedData)
                {
                    if (MessageBox.Show("Цей клієнт має пов'язані дані (підключення, платежі або заявки). " +
                        "Видалення клієнта призведе до видалення всіх пов'язаних даних. Продовжити?",
                        "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    {
                        return; // Користувач відмовився від видалення
                    }

                    // Видаляємо пов'язані дані
                    // Видаляємо підключення
                    string deleteConnectionsQuery = "DELETE FROM Connections WHERE ClientId = @ClientId";
                    using (SqlCommand command = new SqlCommand(deleteConnectionsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ClientId", clientId);
                        command.ExecuteNonQuery();
                    }

                    // Видаляємо платежі
                    string deletePaymentsQuery = "DELETE FROM Payments WHERE ClientId = @ClientId";
                    using (SqlCommand command = new SqlCommand(deletePaymentsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ClientId", clientId);
                        command.ExecuteNonQuery();
                    }

                    // Видаляємо заявки
                    string deleteTicketsQuery = "DELETE FROM SupportTickets WHERE ClientId = @ClientId";
                    using (SqlCommand command = new SqlCommand(deleteTicketsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ClientId", clientId);
                        command.ExecuteNonQuery();
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

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            try
            {
                ClientForm clientForm = new ClientForm();
                if (clientForm.ShowDialog() == DialogResult.OK)
                {
                    LoadClients();
                    MessageBox.Show("Клієнт успішно доданий", "Інформація",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewClients.SelectedRows.Count > 0)
                {
                    // Отримуємо ID вибраного клієнта
                    int clientId = 0;

                    // Спробуємо отримати значення різними способами
                    if (dataGridViewClients.SelectedRows[0].Cells["Id"] != null)
                        clientId = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells["Id"].Value);
                    else if (dataGridViewClients.SelectedRows[0].Cells[0] != null)
                        clientId = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells[0].Value);
                    else
                    {
                        MessageBox.Show("Не вдалося отримати ID клієнта.", "Помилка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Знаходимо клієнта за ID
                    Client selectedClient = clients.FirstOrDefault(c => c.Id == clientId);

                    if (selectedClient != null)
                    {
                        // Створюємо форму для редагування
                        ClientForm clientForm = new ClientForm(selectedClient);

                        // Показуємо форму і перевіряємо результат
                        if (clientForm.ShowDialog() == DialogResult.OK)
                        {
                            // Оновлюємо список клієнтів
                            LoadClients();
                            MessageBox.Show("Клієнт успішно відредагований", "Інформація",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Будь ласка, виберіть клієнта для редагування", "Інформація",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewClients.SelectedRows.Count > 0)
                {
                    // Отримуємо ID вибраного клієнта
                    int clientId = 0;

                    // Спробуємо отримати значення різними способами
                    if (dataGridViewClients.SelectedRows[0].Cells["Id"] != null)
                        clientId = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells["Id"].Value);
                    else if (dataGridViewClients.SelectedRows[0].Cells[0] != null)
                        clientId = Convert.ToInt32(dataGridViewClients.SelectedRows[0].Cells[0].Value);
                    else
                    {
                        MessageBox.Show("Не вдалося отримати ID клієнта.", "Помилка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Запитуємо підтвердження видалення
                    if (MessageBox.Show("Ви впевнені, що хочете видалити цього клієнта?", "Підтвердження",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // Видаляємо клієнта
                        DatabaseManager.DeleteClient(clientId);

                        // Оновлюємо список клієнтів
                        LoadClients();

                        MessageBox.Show("Клієнт успішно видалений", "Інформація",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Будь ласка, виберіть клієнта для видалення", "Інформація",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}