namespace PCC_App.UI
{
    partial class AdminForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.linkToLogout = new System.Windows.Forms.LinkLabel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdateBalance = new System.Windows.Forms.Button();
            this.btnEndSession = new System.Windows.Forms.Button();
            this.dgvActiveSessions = new System.Windows.Forms.DataGridView();
            this.txtSearchNick = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRefreshSession = new System.Windows.Forms.Button();
            this.panelSearchResult = new System.Windows.Forms.Panel();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveSessions)).BeginInit();
            this.panelSearchResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(918, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Личный кабинет";
            // 
            // linkToLogout
            // 
            this.linkToLogout.AutoSize = true;
            this.linkToLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkToLogout.Location = new System.Drawing.Point(993, 167);
            this.linkToLogout.Name = "linkToLogout";
            this.linkToLogout.Size = new System.Drawing.Size(55, 21);
            this.linkToLogout.TabIndex = 1;
            this.linkToLogout.TabStop = true;
            this.linkToLogout.Text = "Выход";
            this.linkToLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToLogout_LinkClicked);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(30, 220);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(170, 33);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdateBalance
            // 
            this.btnUpdateBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnUpdateBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdateBalance.ForeColor = System.Drawing.Color.White;
            this.btnUpdateBalance.Location = new System.Drawing.Point(238, 220);
            this.btnUpdateBalance.Name = "btnUpdateBalance";
            this.btnUpdateBalance.Size = new System.Drawing.Size(146, 33);
            this.btnUpdateBalance.TabIndex = 3;
            this.btnUpdateBalance.Text = "Пополнить";
            this.btnUpdateBalance.UseVisualStyleBackColor = false;
            this.btnUpdateBalance.Click += new System.EventHandler(this.btnUpdateBalance_Click);
            // 
            // btnEndSession
            // 
            this.btnEndSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnEndSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndSession.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEndSession.ForeColor = System.Drawing.Color.White;
            this.btnEndSession.Location = new System.Drawing.Point(435, 492);
            this.btnEndSession.Name = "btnEndSession";
            this.btnEndSession.Size = new System.Drawing.Size(208, 46);
            this.btnEndSession.TabIndex = 4;
            this.btnEndSession.Text = "Завершить сессию";
            this.btnEndSession.UseVisualStyleBackColor = false;
            this.btnEndSession.Click += new System.EventHandler(this.btnEndSession_Click);
            // 
            // dgvActiveSessions
            // 
            this.dgvActiveSessions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActiveSessions.Location = new System.Drawing.Point(30, 401);
            this.dgvActiveSessions.Name = "dgvActiveSessions";
            this.dgvActiveSessions.Size = new System.Drawing.Size(354, 210);
            this.dgvActiveSessions.TabIndex = 5;
            // 
            // txtSearchNick
            // 
            this.txtSearchNick.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearchNick.Location = new System.Drawing.Point(30, 167);
            this.txtSearchNick.Name = "txtSearchNick";
            this.txtSearchNick.Size = new System.Drawing.Size(170, 29);
            this.txtSearchNick.TabIndex = 6;
            this.txtSearchNick.TextChanged += new System.EventHandler(this.txtSearchNick_TextChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtAmount.Location = new System.Drawing.Point(238, 167);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(146, 29);
            this.txtAmount.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(25, 325);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "Активные сессии:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(25, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "Пополнение баланса:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(876, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Роль:   Администратор";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(31, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(330, 30);
            this.label5.TabIndex = 11;
            this.label5.Text = "Информация о пользователе: ";
            // 
            // btnRefreshSession
            // 
            this.btnRefreshSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.btnRefreshSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshSession.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRefreshSession.ForeColor = System.Drawing.Color.White;
            this.btnRefreshSession.Location = new System.Drawing.Point(435, 401);
            this.btnRefreshSession.Name = "btnRefreshSession";
            this.btnRefreshSession.Size = new System.Drawing.Size(208, 46);
            this.btnRefreshSession.TabIndex = 12;
            this.btnRefreshSession.Text = "Обновить";
            this.btnRefreshSession.UseVisualStyleBackColor = false;
            this.btnRefreshSession.Click += new System.EventHandler(this.btnRefreshSession_Click);
            // 
            // panelSearchResult
            // 
            this.panelSearchResult.Controls.Add(this.lblCurrentBalance);
            this.panelSearchResult.Controls.Add(this.lblFullName);
            this.panelSearchResult.Controls.Add(this.label5);
            this.panelSearchResult.Location = new System.Drawing.Point(408, 81);
            this.panelSearchResult.Name = "panelSearchResult";
            this.panelSearchResult.Size = new System.Drawing.Size(462, 236);
            this.panelSearchResult.TabIndex = 13;
            this.panelSearchResult.Visible = false;
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.AutoSize = true;
            this.lblCurrentBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentBalance.Location = new System.Drawing.Point(62, 151);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(52, 21);
            this.lblCurrentBalance.TabIndex = 13;
            this.lblCurrentBalance.Text = "label6";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFullName.Location = new System.Drawing.Point(62, 101);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(52, 21);
            this.lblFullName.TabIndex = 12;
            this.lblFullName.Text = "label6";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.panelSearchResult);
            this.Controls.Add(this.btnRefreshSession);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtSearchNick);
            this.Controls.Add(this.dgvActiveSessions);
            this.Controls.Add(this.btnEndSession);
            this.Controls.Add(this.btnUpdateBalance);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.linkToLogout);
            this.Controls.Add(this.label1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvActiveSessions)).EndInit();
            this.panelSearchResult.ResumeLayout(false);
            this.panelSearchResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkToLogout;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdateBalance;
        private System.Windows.Forms.Button btnEndSession;
        private System.Windows.Forms.DataGridView dgvActiveSessions;
        private System.Windows.Forms.TextBox txtSearchNick;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefreshSession;
        private System.Windows.Forms.Panel panelSearchResult;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.Label lblFullName;
    }
}