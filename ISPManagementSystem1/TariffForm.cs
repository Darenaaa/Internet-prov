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
using System.Xml.Linq;

namespace ISPManagementSystem1
{
    public partial class TariffForm : Form
    {
        private Tariff tariff;
        private bool isEditing;

        // Конструктор для створення нового тарифу
        public TariffForm()
        {
            InitializeComponent();
            tariff = new Tariff();
            isEditing = false;
            checkBoxIsActive.Checked = true;
        }

        // Конструктор для редагування існуючого тарифу
        public TariffForm(Tariff tariff)
        {
            InitializeComponent();
            this.tariff = tariff;
            isEditing = true;

            // Заповнюємо поля даними тарифу
            txtName.Text = tariff.Name;
            numericPrice.Value = tariff.Price;
            numericSpeed.Value = tariff.SpeedMbps;
            txtDescription.Text = tariff.Description;
            checkBoxIsActive.Checked = tariff.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    // Заповнюємо об'єкт тарифу даними з форми
                    tariff.Name = txtName.Text.Trim();
                    tariff.Price = numericPrice.Value;
                    tariff.SpeedMbps = (int)numericSpeed.Value;
                    tariff.Description = txtDescription.Text.Trim();
                    tariff.IsActive = checkBoxIsActive.Checked;

                    // Зберігаємо тариф в базу даних
                    if (isEditing)
                    {
                        DatabaseManager.UpdateTariff(tariff);
                    }
                    else
                    {
                        DatabaseManager.AddTariff(tariff);
                    }

                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні тарифу: {ex.Message}", "Помилка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateForm()
        {
            // Перевірка назви тарифу
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Будь ласка, введіть назву тарифу", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }

            // Перевірка ціни
            if (numericPrice.Value <= 0)
            {
                MessageBox.Show("Будь ласка, введіть коректну ціну тарифу", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericPrice.Focus();
                return false;
            }

            // Перевірка швидкості
            if (numericSpeed.Value <= 0)
            {
                MessageBox.Show("Будь ласка, введіть коректну швидкість", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericSpeed.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}