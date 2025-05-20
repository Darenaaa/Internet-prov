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

namespace ISPManagementSystem1
{
    public partial class QuickPaymentForm : Form
    {
        private List<Client> clients;

        public QuickPaymentForm()
        {
            InitializeComponent();
            this.Load += QuickPaymentForm_Load;
        }

        private void QuickPaymentForm_Load(object sender, EventArgs e)
        {
            LoadClientsAndPaymentMethods();
        }

        private void LoadClientsAndPaymentMethods()
        {
            try
            {
                // Завантаження списку клієнтів
                clients = DatabaseManager.GetAllClients();
                comboBoxClient.DisplayMember = "FullName";
                comboBoxClient.ValueMember = "Id";
                comboBoxClient.DataSource = clients;

                // Завантаження методів оплати
                comboBoxPaymentMethod.Items.Clear();
                comboBoxPaymentMethod.Items.Add("Готівка");
                comboBoxPaymentMethod.Items.Add("Картка");
                comboBoxPaymentMethod.Items.Add("Банківський переказ");
                comboBoxPaymentMethod.Items.Add("Онлайн-платіж");
                comboBoxPaymentMethod.SelectedIndex = 0;

                // Встановлення поточної дати
                dateTimePickerPayment.Value = DateTime.Now;

                // Встановлення опису за замовчуванням
                txtDescription.Text = "Оплата послуг інтернет";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні даних: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    // Створення нового платежу
                    Payment payment = new Payment
                    {
                        ClientId = (int)comboBoxClient.SelectedValue,
                        Amount = numericAmount.Value,
                        PaymentDate = dateTimePickerPayment.Value,
                        PaymentMethod = comboBoxPaymentMethod.Text,
                        Description = txtDescription.Text.Trim()
                    };

                    // Додавання платежу в базу даних
                   

                    MessageBox.Show("Платіж успішно додано", "Інформація",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні платежу: {ex.Message}", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateForm()
        {
            // Перевірка вибору клієнта
            if (comboBoxClient.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, виберіть клієнта", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxClient.Focus();
                return false;
            }

            // Перевірка суми платежу
            if (numericAmount.Value <= 0)
            {
                MessageBox.Show("Будь ласка, введіть коректну суму платежу", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericAmount.Focus();
                return false;
            }

            // Перевірка вибору методу оплати
            if (comboBoxPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, виберіть спосіб оплати", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxPaymentMethod.Focus();
                return false;
            }

            return true;
        }
    }
}
