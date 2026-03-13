namespace KinematicsTask
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTime = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.lblConstants = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInput = new System.Windows.Forms.Label();
            this.pictureBoxScheme = new System.Windows.Forms.PictureBox();

            // ========== НАСТРОЙКА ФОРМЫ ==========
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Text = "Кинематика: Задание №2 (Команда Акатцуки)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MinimumSize = new System.Drawing.Size(850, 650);

            // Заголовок
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle.Text = "Расчет кинематических параметров механизма";
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);

            

            // Блок констант
            this.lblConstants = new System.Windows.Forms.Label();
            this.lblConstants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConstants.Location = new System.Drawing.Point(20, 55);
            this.lblConstants.Size = new System.Drawing.Size(260, 120);
            this.lblConstants.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblConstants.Text = "Загрузка данных...";

            // Ввод времени
            this.lblInput = new System.Windows.Forms.Label();
            this.lblInput.Text = "Время t (с):";
            this.lblInput.Location = new System.Drawing.Point(20, 185);
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);

            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtTime.Location = new System.Drawing.Point(20, 215);
            this.txtTime.Size = new System.Drawing.Size(260, 23);
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);

            // Кнопка
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnCalculate.Text = "РАССЧИТАТЬ";
            this.btnCalculate.Location = new System.Drawing.Point(20, 255);
            this.btnCalculate.Size = new System.Drawing.Size(260, 45);
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCalculate.BackColor = System.Drawing.Color.LightBlue;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);

            // Изображение
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScheme)).BeginInit();
            this.pictureBoxScheme.Location = new System.Drawing.Point(20, 315);
            this.pictureBoxScheme.Size = new System.Drawing.Size(260, 350); 
            this.pictureBoxScheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxScheme.ImageLocation = "scheme.jpg";
            this.pictureBoxScheme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxScheme.BackColor = System.Drawing.Color.White;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScheme)).EndInit();

            // ПРАВАЯ КОЛОНКА 
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.dgvResults.Location = new System.Drawing.Point(300, 256);
            this.dgvResults.Size = new System.Drawing.Size(580, 410); 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dgvResults.RowHeadersWidth = 25;
            this.dgvResults.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical; 

            // Статус
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatus.Location = new System.Drawing.Point(20, 670);
            this.lblStatus.Size = new System.Drawing.Size(860, 25);
            this.lblStatus.Text = "Ожидание...";
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            //Условие задачи
            this.lblText = new System.Windows.Forms.Label();
            this.lblText.Location = new System.Drawing.Point(300, 55);
            this.lblText.Size = new System.Drawing.Size(580, 160);
            this.lblText.Text = "Механизм (рис. 2.2) состоит из двух блоков 2 и 3, каждый из которых\r\nобразован" +
                " совокупностью жестко связанных большого и малого цилиндров.\r\nБольшой цилиндр 2 взаимодействует" +
                " (без скольжения) с малым цилиндром 3 в\r\nточке В. Малый цилиндр 2 НЕ взаимодействует с большим" +
                " цилиндром 3. К\r\nмалому цилиндру 2 в точке А на «нерастяжимом тросе» подвешен груз 1,\r\nкоторый" +
                " совершает «прямолинейное движение» по заданному уравнению.\r\nОпределить «путь», пройденный грузом" +
                " 1, а так же «скорость», «нормальное»,\r\n«тангенциальное» и «полное ускорение» точки М большого" +
                " цилиндра блока 3\r\nмеханизма в момент времени t .";
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Добавление элементов
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblConstants);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.pictureBoxScheme);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblText);
        }

        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Label lblConstants;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.PictureBox pictureBoxScheme;
    }
}