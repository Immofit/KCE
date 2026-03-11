using System;
using System.Windows.Forms;
using System.Drawing;

namespace KinematicsTask
{
    public partial class MainForm : Form
    {
        private KinematicsCalculator _calculator;

        public MainForm()
        {
            InitializeComponent();
            _calculator = new KinematicsCalculator();
            InitializeConstantsDisplay();
            SetupDataGridView();
        }

        private void InitializeConstantsDisplay()
        {
            lblConstants.Text = $"Константы (мм):\n" +
                                $"R2_big = {KinematicsCalculator.R2_BIG}\n" +
                                $"R2_small = {KinematicsCalculator.R2_SMALL}\n" +
                                $"R3_big = {KinematicsCalculator.R3_BIG}\n" +
                                $"R3_small = {KinematicsCalculator.R3_SMALL}\n\n" +
                                $"Уравнение S(t):\n" +
                                $"{KinematicsCalculator.EQ_A}t² + {KinematicsCalculator.EQ_B}t + {KinematicsCalculator.EQ_C}";
        }

        private void SetupDataGridView()
        {
            dgvResults.Columns.Clear();
            dgvResults.Columns.Add("Object", "Объект");
            dgvResults.Columns.Add("Parameter", "Параметр");
            dgvResults.Columns.Add("Value", "Значение");
            dgvResults.Columns[0].Width = 100;
            dgvResults.Columns[1].Width = 140;
            dgvResults.Columns[2].Width = 140;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.ReadOnly = true;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtTime.Text, out double t))
            {
                MessageBox.Show("Введите корректное число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (t < 0)
            {
                MessageBox.Show("Время не может быть отрицательным!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var res = _calculator.Calculate(t);
                dgvResults.Rows.Clear();

                AddRow("Груз 1", "Путь", $"{res.S1:F3} мм");
                AddRow("Груз 1", "Скорость", $"{res.V1 / 1000.0:F3} м/с");
                AddRow("Груз 1", "Ускорение", $"{res.A1 / 1000.0:F3} м/с²");
                AddRow("Блок 2", "Угловая скорость", $"{res.Omega2:F3} рад/с");
                AddRow("Блок 2", "Угловое ускорение", $"{res.Epsilon2:F3} рад/с²");
                AddRow("Точка A", "Скорость", $"{res.Va / 1000.0:F3} м/с");
                AddRow("Точка A", "Танг. ускорение", $"{res.Ata / 1000.0:F3} м/с²");
                AddRow("Точка B", "Скорость", $"{res.Vb / 1000.0:F3} м/с");
                AddRow("Точка B", "Танг. ускорение", $"{res.Atb / 1000.0:F3} м/с²");
                AddRow("Блок 3", "Угловая скорость", $"{res.Omega3:F3} рад/с");
                AddRow("Блок 3", "Угловое ускорение", $"{res.Epsilon3:F3} рад/с²");
                AddRow("Точка M", "Скорость", $"{res.Vm:F3} м/с");
                AddRow("Точка M", "Норм. ускорение", $"{res.AnM:F3} м/с²");
                AddRow("Точка M", "Танг. ускорение", $"{res.AtM:F3} м/с²");
                AddRow("Точка M", "Полное ускорение", $"{res.ATotalM:F3} м/с²");

                lblStatus.Text = $"Готово (t = {t} с)";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Сбой", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRow(string obj, string param, string value)
        {
            dgvResults.Rows.Add(obj, param, value);
        }
    }
}