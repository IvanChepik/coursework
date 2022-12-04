namespace courseWork
{
    partial class MainForm
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
            this.insurancesGroupBox = new System.Windows.Forms.GroupBox();
            this.insuranceBuyButton = new System.Windows.Forms.Button();
            this.insurancesDataGridView = new System.Windows.Forms.DataGridView();
            this.userInsuranceGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteUserInsuranceButton = new System.Windows.Forms.Button();
            this.userInsurancesDataGridView = new System.Windows.Forms.DataGridView();
            this.userLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.outlogButton = new System.Windows.Forms.Button();
            this.insurancesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insurancesDataGridView)).BeginInit();
            this.userInsuranceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInsurancesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // insurancesGroupBox
            // 
            this.insurancesGroupBox.Controls.Add(this.insuranceBuyButton);
            this.insurancesGroupBox.Controls.Add(this.insurancesDataGridView);
            this.insurancesGroupBox.Location = new System.Drawing.Point(43, 72);
            this.insurancesGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insurancesGroupBox.Name = "insurancesGroupBox";
            this.insurancesGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insurancesGroupBox.Size = new System.Drawing.Size(605, 666);
            this.insurancesGroupBox.TabIndex = 2;
            this.insurancesGroupBox.TabStop = false;
            this.insurancesGroupBox.Text = "Страховки";
            // 
            // insuranceBuyButton
            // 
            this.insuranceBuyButton.Location = new System.Drawing.Point(41, 60);
            this.insuranceBuyButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insuranceBuyButton.Name = "insuranceBuyButton";
            this.insuranceBuyButton.Size = new System.Drawing.Size(139, 31);
            this.insuranceBuyButton.TabIndex = 3;
            this.insuranceBuyButton.Text = "Купить";
            this.insuranceBuyButton.UseVisualStyleBackColor = true;
            this.insuranceBuyButton.Click += new System.EventHandler(this.insuranceBuyButton_Click);
            // 
            // insurancesDataGridView
            // 
            this.insurancesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.insurancesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.insurancesDataGridView.Location = new System.Drawing.Point(41, 108);
            this.insurancesDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insurancesDataGridView.Name = "insurancesDataGridView";
            this.insurancesDataGridView.RowHeadersWidth = 51;
            this.insurancesDataGridView.RowTemplate.Height = 25;
            this.insurancesDataGridView.Size = new System.Drawing.Size(509, 514);
            this.insurancesDataGridView.TabIndex = 2;
            this.insurancesDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.insurancesDataGridView_ColumnHeaderMouseClick);
            // 
            // userInsuranceGroupBox
            // 
            this.userInsuranceGroupBox.Controls.Add(this.deleteUserInsuranceButton);
            this.userInsuranceGroupBox.Controls.Add(this.userInsurancesDataGridView);
            this.userInsuranceGroupBox.Location = new System.Drawing.Point(702, 72);
            this.userInsuranceGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userInsuranceGroupBox.Name = "userInsuranceGroupBox";
            this.userInsuranceGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userInsuranceGroupBox.Size = new System.Drawing.Size(567, 666);
            this.userInsuranceGroupBox.TabIndex = 4;
            this.userInsuranceGroupBox.TabStop = false;
            this.userInsuranceGroupBox.Text = "Страховки пользователя";
            // 
            // deleteUserInsuranceButton
            // 
            this.deleteUserInsuranceButton.Location = new System.Drawing.Point(37, 59);
            this.deleteUserInsuranceButton.Name = "deleteUserInsuranceButton";
            this.deleteUserInsuranceButton.Size = new System.Drawing.Size(129, 32);
            this.deleteUserInsuranceButton.TabIndex = 3;
            this.deleteUserInsuranceButton.Text = "Удалить";
            this.deleteUserInsuranceButton.UseVisualStyleBackColor = true;
            this.deleteUserInsuranceButton.Click += new System.EventHandler(this.deleteUserInsuranceButton_Click);
            // 
            // userInsurancesDataGridView
            // 
            this.userInsurancesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userInsurancesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userInsurancesDataGridView.Location = new System.Drawing.Point(37, 108);
            this.userInsurancesDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userInsurancesDataGridView.Name = "userInsurancesDataGridView";
            this.userInsurancesDataGridView.RowHeadersWidth = 51;
            this.userInsurancesDataGridView.RowTemplate.Height = 25;
            this.userInsurancesDataGridView.Size = new System.Drawing.Size(498, 514);
            this.userInsurancesDataGridView.TabIndex = 2;
            this.userInsurancesDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.userInsurancesDataGridView_ColumnHeaderMouseClick);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(43, 39);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(104, 15);
            this.userLabel.TabIndex = 5;
            this.userLabel.Text = "ПОЛЬЗОВАТЕЛЬ: ";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(166, 39);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(0, 15);
            this.userNameLabel.TabIndex = 6;
            // 
            // outlogButton
            // 
            this.outlogButton.Location = new System.Drawing.Point(1124, 23);
            this.outlogButton.Name = "outlogButton";
            this.outlogButton.Size = new System.Drawing.Size(145, 42);
            this.outlogButton.TabIndex = 7;
            this.outlogButton.Text = "Выйти из аккаунта";
            this.outlogButton.UseVisualStyleBackColor = true;
            this.outlogButton.Click += new System.EventHandler(this.outlogButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 754);
            this.Controls.Add(this.outlogButton);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.userInsuranceGroupBox);
            this.Controls.Add(this.insurancesGroupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Главная форма";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.insurancesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.insurancesDataGridView)).EndInit();
            this.userInsuranceGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userInsurancesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox insurancesGroupBox;
        private Button insuranceBuyButton;
        private DataGridView insurancesDataGridView;
        private GroupBox userInsuranceGroupBox;
        private DataGridView userInsurancesDataGridView;
        private Label userLabel;
        private Label userNameLabel;
        private Button deleteUserInsuranceButton;
        private Button outlogButton;
    }
}