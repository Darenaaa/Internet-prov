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
    public partial class TariffsForm : Form
    {
        private List<Tariff> tariffs;

        public TariffsForm()
        {
            InitializeComponent();
            this.Load += TariffsForm_Load;
        }

        private void TariffsForm_Load(object sender, EventArgs e)
        {
            LoadTariffs();
        }

        private void LoadTariffs()
        {
            try
            {
                tariffs = DatabaseManager.GetAllTariffs();
                dataGridViewTariffs.DataSource = null;
                dataGridViewTariffs.DataSource = tariffs;

                // Налаштування відображення стовпців
                if (dataGridViewTariffs.Columns.Contains("Id"))
                    dataGridViewTariffs.Columns["Id"].HeaderText = "ID";
                if (dataGridViewTariffs.Columns.Contains("Name"))
                    dataGridViewTariffs.Columns["Name"].HeaderText = "Назва";
                if (dataGridViewTariffs.Columns.Contains("Price"))
                    dataGridViewTariffs.Columns["Price"].HeaderText = "Ціна";
                if (dataGridViewTariffs.Columns.Contains("SpeedMbps"))
                    dataGridViewTariffs.Columns["SpeedMbps"].HeaderText = "Швидкість (Мбіт/с)";
                if (dataGridViewTariffs.Columns.Contains("Description"))
                    dataGridViewTariffs.Columns["Description"].HeaderText = "Опис";
                if (dataGridViewTariffs.Columns.Contains("IsActive"))
                    dataGridViewTariffs.Columns["IsActive"].HeaderText = "Активний";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні тарифів: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTariff_Click(object sender, EventArgs e)
        {
            try
            {
                TariffForm tariffForm = new TariffForm();
                if (tariffForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTariffs();
                    MessageBox.Show("Тариф успішно доданий", "Інформація",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditTariff_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTariffs.SelectedRows.Count > 0)
                {
                    int tariffId = Convert.ToInt32(dataGridViewTariffs.SelectedRows[0].Cells["Id"].Value);
                    Tariff selectedTariff = tariffs.FirstOrDefault(t => t.Id == tariffId);

                    if (selectedTariff != null)
                    {
                        TariffForm tariffForm = new TariffForm(selectedTariff);
                        if (tariffForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadTariffs();
                            MessageBox.Show("Тариф успішно відредагований", "Інформація",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Будь ласка, виберіть тариф для редагування", "Інформація",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTariff_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewTariffs.SelectedRows.Count > 0)
                {
                    int tariffId = Convert.ToInt32(dataGridViewTariffs.SelectedRows[0].Cells["Id"].Value);

                    if (MessageBox.Show("Ви впевнені, що хочете видалити цей тариф?", "Підтвердження",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DatabaseManager.DeleteTariff(tariffId);
                        LoadTariffs();
                        MessageBox.Show("Тариф успішно видалений", "Інформація",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Будь ласка, виберіть тариф для видалення", "Інформація",
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