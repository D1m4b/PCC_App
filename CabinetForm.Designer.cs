namespace PCC_App
{
    partial class CabinetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNickname = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnShowHistory = new System.Windows.Forms.Button();
            this.cmbHalls = new System.Windows.Forms.ComboBox();
            this.cmbComputers = new System.Windows.Forms.ComboBox();
            this.cmbTariffs = new System.Windows.Forms.ComboBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.btnBook = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkToLogout = new System.Windows.Forms.LinkLabel();
            this.linkTopUp = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelTopUp = new System.Windows.Forms.Panel();
            this.btnTopUp = new System.Windows.Forms.Button();
            this.txtTopUpAmount = new System.Windows.Forms.TextBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpBookingTime = new System.Windows.Forms.DateTimePicker();
            this.dtpBookingDate = new System.Windows.Forms.DateTimePicker();
            this.cmbHours = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.panelTopUp.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNickname.Location = new System.Drawing.Point(140, 86);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(75, 21);
            this.lblNickname.TabIndex = 0;
            this.lblNickname.Text = "Никнейм";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBalance.Location = new System.Drawing.Point(140, 134);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(59, 21);
            this.lblBalance.TabIndex = 2;
            this.lblBalance.Text = "Баланс";
            // 
            // dgvHistory
            // 
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(402, 164);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.Size = new System.Drawing.Size(576, 232);
            this.dgvHistory.TabIndex = 3;
            // 
            // btnShowHistory
            // 
            this.btnShowHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnShowHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnShowHistory.ForeColor = System.Drawing.Color.White;
            this.btnShowHistory.Location = new System.Drawing.Point(552, 72);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.Size = new System.Drawing.Size(174, 40);
            this.btnShowHistory.TabIndex = 4;
            this.btnShowHistory.Text = "Моя история";
            this.btnShowHistory.UseVisualStyleBackColor = false;
            this.btnShowHistory.Click += new System.EventHandler(this.btnShowHistory_Click);
            // 
            // cmbHalls
            // 
            this.cmbHalls.FormattingEnabled = true;
            this.cmbHalls.Location = new System.Drawing.Point(163, 134);
            this.cmbHalls.Name = "cmbHalls";
            this.cmbHalls.Size = new System.Drawing.Size(200, 21);
            this.cmbHalls.TabIndex = 5;
            this.cmbHalls.SelectedIndexChanged += new System.EventHandler(this.cmbHalls_SelectedIndexChanged);
            // 
            // cmbComputers
            // 
            this.cmbComputers.FormattingEnabled = true;
            this.cmbComputers.Location = new System.Drawing.Point(164, 227);
            this.cmbComputers.Name = "cmbComputers";
            this.cmbComputers.Size = new System.Drawing.Size(199, 21);
            this.cmbComputers.TabIndex = 6;
            // 
            // cmbTariffs
            // 
            this.cmbTariffs.FormattingEnabled = true;
            this.cmbTariffs.Location = new System.Drawing.Point(164, 179);
            this.cmbTariffs.Name = "cmbTariffs";
            this.cmbTariffs.Size = new System.Drawing.Size(199, 21);
            this.cmbTariffs.TabIndex = 7;
            this.cmbTariffs.SelectedIndexChanged += new System.EventHandler(this.cmbTariffs_SelectedIndexChanged);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(184, 315);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(179, 20);
            this.txtTotalPrice.TabIndex = 8;
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(25, 361);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(238, 35);
            this.btnBook.TabIndex = 9;
            this.btnBook.Text = "Забронировать";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(863, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Роль: Пользователь";
            // 
            // linkToLogout
            // 
            this.linkToLogout.AutoSize = true;
            this.linkToLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkToLogout.Location = new System.Drawing.Point(958, 215);
            this.linkToLogout.Name = "linkToLogout";
            this.linkToLogout.Size = new System.Drawing.Size(55, 21);
            this.linkToLogout.TabIndex = 11;
            this.linkToLogout.TabStop = true;
            this.linkToLogout.Text = "Выход";
            this.linkToLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToLogout_LinkClicked);
            // 
            // linkTopUp
            // 
            this.linkTopUp.AutoSize = true;
            this.linkTopUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkTopUp.Location = new System.Drawing.Point(871, 166);
            this.linkTopUp.Name = "linkTopUp";
            this.linkTopUp.Size = new System.Drawing.Size(142, 21);
            this.linkTopUp.TabIndex = 13;
            this.linkTopUp.TabStop = true;
            this.linkTopUp.Text = "Пополнить баланс";
            this.linkTopUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTopUp_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(22, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Выберите: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(23, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Тариф";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(23, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 21);
            this.label5.TabIndex = 16;
            this.label5.Text = "Зал";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(22, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "Место";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(547, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 30);
            this.label7.TabIndex = 18;
            this.label7.Text = "История игровых сессий:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(883, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Личный кабинет";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(21, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 21);
            this.label8.TabIndex = 20;
            this.label8.Text = "Итоговая сумма";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(20, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(306, 30);
            this.label9.TabIndex = 21;
            this.label9.Text = "Бронирование компьютера:";
            // 
            // panelTopUp
            // 
            this.panelTopUp.Controls.Add(this.btnTopUp);
            this.panelTopUp.Controls.Add(this.txtTopUpAmount);
            this.panelTopUp.Location = new System.Drawing.Point(301, 47);
            this.panelTopUp.Name = "panelTopUp";
            this.panelTopUp.Size = new System.Drawing.Size(431, 232);
            this.panelTopUp.TabIndex = 22;
            this.panelTopUp.Visible = false;
            // 
            // btnTopUp
            // 
            this.btnTopUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnTopUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTopUp.ForeColor = System.Drawing.Color.White;
            this.btnTopUp.Location = new System.Drawing.Point(125, 104);
            this.btnTopUp.Name = "btnTopUp";
            this.btnTopUp.Size = new System.Drawing.Size(201, 34);
            this.btnTopUp.TabIndex = 1;
            this.btnTopUp.Text = "Пополнить";
            this.btnTopUp.UseVisualStyleBackColor = false;
            this.btnTopUp.Click += new System.EventHandler(this.btnTopUp_Click);
            // 
            // txtTopUpAmount
            // 
            this.txtTopUpAmount.Location = new System.Drawing.Point(125, 58);
            this.txtTopUpAmount.Name = "txtTopUpAmount";
            this.txtTopUpAmount.Size = new System.Drawing.Size(201, 20);
            this.txtTopUpAmount.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.label13);
            this.panelMain.Controls.Add(this.dtpBookingTime);
            this.panelMain.Controls.Add(this.dtpBookingDate);
            this.panelMain.Controls.Add(this.cmbHours);
            this.panelMain.Controls.Add(this.label10);
            this.panelMain.Controls.Add(this.label9);
            this.panelMain.Controls.Add(this.dgvHistory);
            this.panelMain.Controls.Add(this.btnShowHistory);
            this.panelMain.Controls.Add(this.label8);
            this.panelMain.Controls.Add(this.cmbHalls);
            this.panelMain.Controls.Add(this.cmbComputers);
            this.panelMain.Controls.Add(this.label7);
            this.panelMain.Controls.Add(this.cmbTariffs);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.txtTotalPrice);
            this.panelMain.Controls.Add(this.label5);
            this.panelMain.Controls.Add(this.btnBook);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Location = new System.Drawing.Point(35, 239);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1068, 411);
            this.panelMain.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(23, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 21);
            this.label13.TabIndex = 27;
            this.label13.Text = "Дату и время";
            // 
            // dtpBookingTime
            // 
            this.dtpBookingTime.CustomFormat = "HH:mm";
            this.dtpBookingTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBookingTime.Location = new System.Drawing.Point(163, 92);
            this.dtpBookingTime.Name = "dtpBookingTime";
            this.dtpBookingTime.ShowUpDown = true;
            this.dtpBookingTime.Size = new System.Drawing.Size(200, 20);
            this.dtpBookingTime.TabIndex = 26;
            this.dtpBookingTime.ValueChanged += new System.EventHandler(this.dtpBookingTime_ValueChanged);
            // 
            // dtpBookingDate
            // 
            this.dtpBookingDate.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpBookingDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBookingDate.Location = new System.Drawing.Point(163, 46);
            this.dtpBookingDate.Name = "dtpBookingDate";
            this.dtpBookingDate.Size = new System.Drawing.Size(200, 20);
            this.dtpBookingDate.TabIndex = 25;
            this.dtpBookingDate.ValueChanged += new System.EventHandler(this.dtpBookingDate_ValueChanged);
            // 
            // cmbHours
            // 
            this.cmbHours.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.cmbHours.FormattingEnabled = true;
            this.cmbHours.Location = new System.Drawing.Point(164, 275);
            this.cmbHours.Name = "cmbHours";
            this.cmbHours.Size = new System.Drawing.Size(199, 21);
            this.cmbHours.TabIndex = 24;
            this.cmbHours.SelectedIndexChanged += new System.EventHandler(this.cmbHours_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(23, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 21);
            this.label10.TabIndex = 23;
            this.label10.Text = "Кол-во часов";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(56, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 21);
            this.label11.TabIndex = 24;
            this.label11.Text = "Никнейм:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(56, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 21);
            this.label12.TabIndex = 25;
            this.label12.Text = "Баланс:";
            // 
            // CabinetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTopUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkTopUp);
            this.Controls.Add(this.linkToLogout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblNickname);
            this.Name = "CabinetForm";
            this.Text = "CabinetForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.panelTopUp.ResumeLayout(false);
            this.panelTopUp.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnShowHistory;
        private System.Windows.Forms.ComboBox cmbHalls;
        private System.Windows.Forms.ComboBox cmbComputers;
        private System.Windows.Forms.ComboBox cmbTariffs;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkToLogout;
        private System.Windows.Forms.LinkLabel linkTopUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelTopUp;
        private System.Windows.Forms.TextBox txtTopUpAmount;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnTopUp;
        private System.Windows.Forms.ComboBox cmbHours;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpBookingDate;
        private System.Windows.Forms.DateTimePicker dtpBookingTime;
        private System.Windows.Forms.Label label13;
    }
}
