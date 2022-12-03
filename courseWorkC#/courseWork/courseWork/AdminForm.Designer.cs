namespace courseWork
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
            this.usersGroupBox = new System.Windows.Forms.GroupBox();
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.insurancesGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteInsuranceButton = new System.Windows.Forms.Button();
            this.insuranceEditButton = new System.Windows.Forms.Button();
            this.insuranceAddButton = new System.Windows.Forms.Button();
            this.insurancesDataGridView = new System.Windows.Forms.DataGridView();
            this.outlogButton = new System.Windows.Forms.Button();
            this.usersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.insurancesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.insurancesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // usersGroupBox
            // 
            this.usersGroupBox.Controls.Add(this.usersDataGridView);
            this.usersGroupBox.Location = new System.Drawing.Point(688, 91);
            this.usersGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usersGroupBox.Name = "usersGroupBox";
            this.usersGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usersGroupBox.Size = new System.Drawing.Size(601, 776);
            this.usersGroupBox.TabIndex = 0;
            this.usersGroupBox.TabStop = false;
            this.usersGroupBox.Text = "Пользователи";
            // 
            // usersDataGridView
            // 
            this.usersDataGridView.AllowUserToAddRows = false;
            this.usersDataGridView.AllowUserToDeleteRows = false;
            this.usersDataGridView.AllowUserToResizeColumns = false;
            this.usersDataGridView.AllowUserToResizeRows = false;
            this.usersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usersDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.usersDataGridView.EnableHeadersVisualStyles = false;
            this.usersDataGridView.Location = new System.Drawing.Point(30, 95);
            this.usersDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.ReadOnly = true;
            this.usersDataGridView.RowHeadersWidth = 51;
            this.usersDataGridView.RowTemplate.Height = 25;
            this.usersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersDataGridView.Size = new System.Drawing.Size(565, 652);
            this.usersDataGridView.TabIndex = 3;
            this.usersDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.usersDataGridView_CellMouseClick);
            // 
            // insurancesGroupBox
            // 
            this.insurancesGroupBox.Controls.Add(this.deleteInsuranceButton);
            this.insurancesGroupBox.Controls.Add(this.insuranceEditButton);
            this.insurancesGroupBox.Controls.Add(this.insuranceAddButton);
            this.insurancesGroupBox.Controls.Add(this.insurancesDataGridView);
            this.insurancesGroupBox.Location = new System.Drawing.Point(42, 91);
            this.insurancesGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insurancesGroupBox.Name = "insurancesGroupBox";
            this.insurancesGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insurancesGroupBox.Size = new System.Drawing.Size(601, 776);
            this.insurancesGroupBox.TabIndex = 1;
            this.insurancesGroupBox.TabStop = false;
            this.insurancesGroupBox.Text = "Страховки";
            // 
            // deleteInsuranceButton
            // 
            this.deleteInsuranceButton.Location = new System.Drawing.Point(416, 29);
            this.deleteInsuranceButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteInsuranceButton.Name = "deleteInsuranceButton";
            this.deleteInsuranceButton.Size = new System.Drawing.Size(167, 47);
            this.deleteInsuranceButton.TabIndex = 5;
            this.deleteInsuranceButton.Text = "Удалить";
            this.deleteInsuranceButton.UseVisualStyleBackColor = true;
            this.deleteInsuranceButton.Click += new System.EventHandler(this.deleteInsuranceButton_Click);
            // 
            // insuranceEditButton
            // 
            this.insuranceEditButton.Location = new System.Drawing.Point(218, 29);
            this.insuranceEditButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insuranceEditButton.Name = "insuranceEditButton";
            this.insuranceEditButton.Size = new System.Drawing.Size(167, 47);
            this.insuranceEditButton.TabIndex = 4;
            this.insuranceEditButton.Text = "Редактировать";
            this.insuranceEditButton.UseVisualStyleBackColor = true;
            this.insuranceEditButton.Click += new System.EventHandler(this.insuranceEditButton_Click);
            // 
            // insuranceAddButton
            // 
            this.insuranceAddButton.Location = new System.Drawing.Point(18, 29);
            this.insuranceAddButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insuranceAddButton.Name = "insuranceAddButton";
            this.insuranceAddButton.Size = new System.Drawing.Size(168, 47);
            this.insuranceAddButton.TabIndex = 3;
            this.insuranceAddButton.Text = "Добавить";
            this.insuranceAddButton.UseVisualStyleBackColor = true;
            this.insuranceAddButton.Click += new System.EventHandler(this.insuranceAddButton_Click);
            // 
            // insurancesDataGridView
            // 
            this.insurancesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.insurancesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.insurancesDataGridView.Location = new System.Drawing.Point(18, 95);
            this.insurancesDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.insurancesDataGridView.Name = "insurancesDataGridView";
            this.insurancesDataGridView.RowHeadersWidth = 51;
            this.insurancesDataGridView.RowTemplate.Height = 25;
            this.insurancesDataGridView.Size = new System.Drawing.Size(565, 652);
            this.insurancesDataGridView.TabIndex = 2;
            this.insurancesDataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.insurancesDataGridView_ColumnHeaderMouseClick);
            // 
            // outlogButton
            // 
            this.outlogButton.Location = new System.Drawing.Point(1123, 16);
            this.outlogButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.outlogButton.Name = "outlogButton";
            this.outlogButton.Size = new System.Drawing.Size(166, 67);
            this.outlogButton.TabIndex = 2;
            this.outlogButton.Text = "Выйти из аккаунта";
            this.outlogButton.UseVisualStyleBackColor = true;
            this.outlogButton.Click += new System.EventHandler(this.outlogButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 896);
            this.Controls.Add(this.outlogButton);
            this.Controls.Add(this.insurancesGroupBox);
            this.Controls.Add(this.usersGroupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminForm";
            this.Text = "Форма админа";
            this.usersGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.insurancesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.insurancesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox usersGroupBox;
        private GroupBox insurancesGroupBox;
        private DataGridView insurancesDataGridView;
        private DataGridView usersDataGridView;
        private Button insuranceAddButton;
        private Button insuranceEditButton;
        private Button outlogButton;
        private Button deleteInsuranceButton;
    }
}