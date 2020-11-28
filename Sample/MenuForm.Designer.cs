namespace DBSorter
{
    partial class MenuForm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.topLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.openButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.chooseTopPanel = new System.Windows.Forms.Panel();
            this.chooseTopLabel = new System.Windows.Forms.Label();
            this.chooseTypeBottomPanel = new System.Windows.Forms.Panel();
            this.mdbButton = new System.Windows.Forms.Button();
            this.accdbButton = new System.Windows.Forms.Button();
            this.tableGridView = new System.Windows.Forms.DataGridView();
            this.tableConfirmButton = new System.Windows.Forms.Button();
            this.tableSelectPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.chooseTopPanel.SuspendLayout();
            this.chooseTypeBottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).BeginInit();
            this.tableSelectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.topPanel.Controls.Add(this.topLabel);
            this.topPanel.Location = new System.Drawing.Point(16, 15);
            this.topPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(487, 124);
            this.topPanel.TabIndex = 2;
            // 
            // topLabel
            // 
            this.topLabel.AutoSize = true;
            this.topLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.topLabel.Location = new System.Drawing.Point(15, 37);
            this.topLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(435, 39);
            this.topLabel.TabIndex = 0;
            this.topLabel.Text = "Сортировщик Баз Данных";
            this.topLabel.Click += new System.EventHandler(this.topLabel_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bottomPanel.Controls.Add(this.openButton);
            this.bottomPanel.Controls.Add(this.continueButton);
            this.bottomPanel.Location = new System.Drawing.Point(20, 162);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(487, 450);
            this.bottomPanel.TabIndex = 3;
            // 
            // openButton
            // 
            this.openButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.openButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.openButton.Location = new System.Drawing.Point(23, 207);
            this.openButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(436, 159);
            this.openButton.TabIndex = 3;
            this.openButton.Text = "Открыть новый файл";
            this.openButton.UseVisualStyleBackColor = false;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.continueButton.Location = new System.Drawing.Point(23, 20);
            this.continueButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(436, 159);
            this.continueButton.TabIndex = 2;
            this.continueButton.Text = "Продолжить работу с предыдущим файлом";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // chooseTopPanel
            // 
            this.chooseTopPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.chooseTopPanel.Controls.Add(this.chooseTopLabel);
            this.chooseTopPanel.Location = new System.Drawing.Point(16, 162);
            this.chooseTopPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chooseTopPanel.Name = "chooseTopPanel";
            this.chooseTopPanel.Size = new System.Drawing.Size(487, 124);
            this.chooseTopPanel.TabIndex = 3;
            this.chooseTopPanel.Visible = false;
            // 
            // chooseTopLabel
            // 
            this.chooseTopLabel.AutoSize = true;
            this.chooseTopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.chooseTopLabel.Location = new System.Drawing.Point(15, 37);
            this.chooseTopLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.chooseTopLabel.Name = "chooseTopLabel";
            this.chooseTopLabel.Size = new System.Drawing.Size(453, 39);
            this.chooseTopLabel.TabIndex = 0;
            this.chooseTopLabel.Text = "Выберите тип базы данных";
            // 
            // chooseTypeBottomPanel
            // 
            this.chooseTypeBottomPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.chooseTypeBottomPanel.Controls.Add(this.mdbButton);
            this.chooseTypeBottomPanel.Controls.Add(this.accdbButton);
            this.chooseTypeBottomPanel.Location = new System.Drawing.Point(16, 306);
            this.chooseTypeBottomPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chooseTypeBottomPanel.Name = "chooseTypeBottomPanel";
            this.chooseTypeBottomPanel.Size = new System.Drawing.Size(491, 306);
            this.chooseTypeBottomPanel.TabIndex = 4;
            this.chooseTypeBottomPanel.Visible = false;
            // 
            // mdbButton
            // 
            this.mdbButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mdbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.mdbButton.Location = new System.Drawing.Point(27, 145);
            this.mdbButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mdbButton.Name = "mdbButton";
            this.mdbButton.Size = new System.Drawing.Size(436, 118);
            this.mdbButton.TabIndex = 3;
            this.mdbButton.Text = "*.MDB";
            this.mdbButton.UseVisualStyleBackColor = false;
            this.mdbButton.Click += new System.EventHandler(this.mdbButton_Click);
            // 
            // accdbButton
            // 
            this.accdbButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.accdbButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.accdbButton.Location = new System.Drawing.Point(23, 20);
            this.accdbButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.accdbButton.Name = "accdbButton";
            this.accdbButton.Size = new System.Drawing.Size(436, 118);
            this.accdbButton.TabIndex = 2;
            this.accdbButton.Text = "*.ACCDB";
            this.accdbButton.UseVisualStyleBackColor = false;
            this.accdbButton.Click += new System.EventHandler(this.accdbButton_Click);
            // 
            // tableGridView
            // 
            this.tableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGridView.Location = new System.Drawing.Point(19, 21);
            this.tableGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableGridView.Name = "tableGridView";
            this.tableGridView.RowHeadersWidth = 51;
            this.tableGridView.Size = new System.Drawing.Size(449, 190);
            this.tableGridView.TabIndex = 5;
            // 
            // tableConfirmButton
            // 
            this.tableConfirmButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.tableConfirmButton.Location = new System.Drawing.Point(109, 225);
            this.tableConfirmButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableConfirmButton.Name = "tableConfirmButton";
            this.tableConfirmButton.Size = new System.Drawing.Size(257, 55);
            this.tableConfirmButton.TabIndex = 7;
            this.tableConfirmButton.Text = "Подтвердить";
            this.tableConfirmButton.UseVisualStyleBackColor = false;
            this.tableConfirmButton.Click += new System.EventHandler(this.tableConfirmButton_Click);
            // 
            // tableSelectPanel
            // 
            this.tableSelectPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tableSelectPanel.Controls.Add(this.tableConfirmButton);
            this.tableSelectPanel.Controls.Add(this.tableGridView);
            this.tableSelectPanel.Location = new System.Drawing.Point(16, 310);
            this.tableSelectPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableSelectPanel.Name = "tableSelectPanel";
            this.tableSelectPanel.Size = new System.Drawing.Size(491, 306);
            this.tableSelectPanel.TabIndex = 8;
            this.tableSelectPanel.Visible = false;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(519, 628);
            this.Controls.Add(this.tableSelectPanel);
            this.Controls.Add(this.chooseTopPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.chooseTypeBottomPanel);
            this.Controls.Add(this.topPanel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MenuForm";
            this.Text = "Сортировщик БД";
            this.Load += new System.EventHandler(this.SelectDBTypeForm_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.chooseTopPanel.ResumeLayout(false);
            this.chooseTopPanel.PerformLayout();
            this.chooseTypeBottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).EndInit();
            this.tableSelectPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Panel chooseTopPanel;
        private System.Windows.Forms.Label chooseTopLabel;
        private System.Windows.Forms.Panel chooseTypeBottomPanel;
        private System.Windows.Forms.Button mdbButton;
        private System.Windows.Forms.Button accdbButton;
        private System.Windows.Forms.DataGridView tableGridView;
        private System.Windows.Forms.Button tableConfirmButton;
        private System.Windows.Forms.Panel tableSelectPanel;
    }
}