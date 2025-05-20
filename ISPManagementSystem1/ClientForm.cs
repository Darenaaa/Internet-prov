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
    public partial class ClientForm : Form
    {
        private Client client;
        private bool isEditing;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        public ClientForm()
        {
            InitializeComponent();
            client = new Client();
            isEditing = false;
            dateTimePickerRegistration.Value = DateTime.Now;
            checkBoxIsActive.Checked = true;
        }

        public ClientForm(Client client)
        {
            InitializeComponent();
            this.client = client;
            isEditing = true;

            // Заповнюємо поля даними клієнта
            txtFullName.Text = client.FullName;
            txtAddress.Text = client.Address;
            txtPhone.Text = client.Phone;
            txtEmail.Text = client.Email;
            dateTimePickerRegistration.Value = client.RegistrationDate;
            checkBoxIsActive.Checked = client.IsActive;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                // Заповнюємо об'єкт клієнта даними з форми
                client.FullName = txtFullName.Text;
                client.Address = txtAddress.Text;
                client.Phone = txtPhone.Text;
                client.Email = txtEmail.Text;
                client.RegistrationDate = dateTimePickerRegistration.Value;
                client.IsActive = checkBoxIsActive.Checked;

                try
                {
                    if (isEditing)
                    {
                        DatabaseManager.UpdateClient(client);
                    }
                    else
                    {
                        DatabaseManager.AddClient(client);
                    }

                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні клієнта: {ex.Message}", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Будь ласка, введіть ПІБ клієнта", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Будь ласка, введіть адресу клієнта", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Будь ласка, введіть телефон клієнта", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return false;
            }

            return true;
        }
    }
}
