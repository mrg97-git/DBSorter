using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace DBSorter
{
    public class FilterUserControl : System.Windows.Forms.UserControl
    {
        // Create the controls.
        public System.Windows.Forms.ErrorProvider errorProvider1;
        public System.Windows.Forms.TextBox textPattern;
        public System.Windows.Forms.TextBox textThreshold;
        public System.Windows.Forms.TextBox textColumn;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox comboType;
        public System.Windows.Forms.ComboBox comboOrder;
        public System.Windows.Forms.Button deleteButton;
        public System.Windows.Forms.Panel panel;        
        public System.ComponentModel.IContainer components;        

        // Define the constructor.
        public FilterUserControl()
        {
            InitializeComponent();
        }

        // Initialize the control elements.
        public void InitializeComponent()
        {
            // Initialize the controls.
            components = new System.ComponentModel.Container();
            errorProvider1 = new System.Windows.Forms.ErrorProvider();
            textPattern = new System.Windows.Forms.TextBox();
            textThreshold = new System.Windows.Forms.TextBox();
            textColumn = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            comboType = new System.Windows.Forms.ComboBox();
            comboOrder = new System.Windows.Forms.ComboBox();            
            deleteButton = new System.Windows.Forms.Button();
            panel = new System.Windows.Forms.Panel();

            // Set the tab order, text alignment, size, and location of the controls.
            textPattern.Location = new System.Drawing.Point(300, 10);
            textPattern.Size = new System.Drawing.Size(135, 20);

            textThreshold.Location = new System.Drawing.Point(375, 34);
            textThreshold.Size = new System.Drawing.Size(40, 20);

            textColumn.Location = new System.Drawing.Point(68, 34);
            textColumn.Size = new System.Drawing.Size(80, 20);

            label1.Location = new System.Drawing.Point(8, 32);
            label1.Size = new System.Drawing.Size(60, 23);
            label1.Text = "в столбце";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            label1.BackColor = Color.DimGray;

            label2.Location = new System.Drawing.Point(405, 32);
            label2.Size = new System.Drawing.Size(15, 23);
            label2.Text = "%";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            label2.BackColor = Color.DimGray;

            label3.Location = new System.Drawing.Point(150, 32);
            label3.Size = new System.Drawing.Size(110, 23);
            label3.Text = "только совпадения ";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            label3.BackColor = Color.DimGray;

            comboType.Location = new System.Drawing.Point(8, 10);
            comboType.Size = new System.Drawing.Size(290, 20);
            comboType.Items.Add(" Частичные совпадения (% от длины запроса) c ");
            comboType.Items.Add(" Частичные совпадения (% от длины содержимого) c ");
            comboType.Items.Add(" Встречается регулярное выражание ");
            comboType.SelectedIndex = 0;
            this.comboType.SelectedIndexChanged +=
                new System.EventHandler(comboType_SelectedIndexChanged);
            void comboType_SelectedIndexChanged(object sender, EventArgs e)
            {
                switch (comboType.SelectedIndex)
                {
                    case 0:
                        this.textThreshold.Visible = true;
                        this.label2.Visible = true;
                        this.label3.Visible = true;
                        this.comboOrder.Visible = true;
                        break;
                    case 1:
                        this.textThreshold.Visible = true;
                        this.label2.Visible = true;
                        this.label3.Visible = true;
                        this.comboOrder.Visible = true;
                        break;
                    case 2:
                        this.textThreshold.Visible = false;
                        this.label2.Visible = false;
                        this.label3.Visible = false;
                        this.comboOrder.Visible = false;
                        break;
                    default:
                        break;
                }
            }

            comboOrder.Location = new System.Drawing.Point(260, 34);
            comboOrder.Size = new System.Drawing.Size(105, 20);
            comboOrder.Items.Add(" не менее");
            comboOrder.Items.Add(" не более");
            comboOrder.SelectedIndex = 0;
                       
            deleteButton.Location = new System.Drawing.Point(440, 27);
            deleteButton.Size = new System.Drawing.Size(20, 20);
            deleteButton.Text = "X";
            deleteButton.BackColor = Color.White;
            this.deleteButton.Click +=
                new System.EventHandler(deleteButton_Click);
            void deleteButton_Click(object sender, EventArgs e)
            {
                Dispose();
            }

            panel.Location = new System.Drawing.Point(5, 1);
            panel.Size = new System.Drawing.Size(462, 62);
            panel.BackColor = Color.DimGray;

            // Add the controls to the user control.
            Controls.AddRange(new System.Windows.Forms.Control[]
            {
            label1,
            label2,
            label3,
            textPattern,
            textThreshold,
            textColumn,
            comboType,
            comboOrder,
            deleteButton,
            panel            
            });

            // Size the user control.
            Size = new System.Drawing.Size(465, 70);            
        }

        public string ReturnData()
        {
            return (textPattern.Text);
        }

    } // End Class   

    partial class MainWindowForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.addFilterButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.topLeftLabel = new System.Windows.Forms.Label();
            this.topRightLabel = new System.Windows.Forms.Label();
            this.applyFilterButton = new System.Windows.Forms.Button();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.filterLogicTextBox = new System.Windows.Forms.TextBox();
            this.filterLogicComboBox = new System.Windows.Forms.ComboBox();
            this.returnButton = new System.Windows.Forms.Button();
            this.saveDBButton = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.Button();
            this.hideFiltersButton = new System.Windows.Forms.Button();
            this.changeTableButton = new System.Windows.Forms.Button();
            this.loadingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(765, 98);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(768, 694);
            this.dataGridView.TabIndex = 0;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1825, 692);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(209, 28);
            this.button7.TabIndex = 10;
            this.button7.Text = "Find Overlaps";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1851, 628);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(183, 22);
            this.textBox5.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1825, 660);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "в столбце";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1825, 631);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "с";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1909, 656);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(124, 22);
            this.textBox6.TabIndex = 17;
            // 
            // addFilterButton
            // 
            this.addFilterButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.addFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.addFilterButton.Location = new System.Drawing.Point(109, 549);
            this.addFilterButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addFilterButton.Name = "addFilterButton";
            this.addFilterButton.Size = new System.Drawing.Size(187, 62);
            this.addFilterButton.TabIndex = 24;
            this.addFilterButton.Text = "Добавить фильтр";
            this.addFilterButton.UseVisualStyleBackColor = false;
            this.addFilterButton.Click += new System.EventHandler(this.addFilterButton_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(629, 538);
            this.flowLayoutPanel.TabIndex = 25;
            this.flowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // topLeftLabel
            // 
            this.topLeftLabel.AutoSize = true;
            this.topLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.topLeftLabel.Location = new System.Drawing.Point(329, 36);
            this.topLeftLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.topLeftLabel.Name = "topLeftLabel";
            this.topLeftLabel.Size = new System.Drawing.Size(205, 51);
            this.topLeftLabel.TabIndex = 26;
            this.topLeftLabel.Text = "Фильтры";
            // 
            // topRightLabel
            // 
            this.topRightLabel.AutoSize = true;
            this.topRightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.topRightLabel.Location = new System.Drawing.Point(1016, 36);
            this.topRightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.topRightLabel.Name = "topRightLabel";
            this.topRightLabel.Size = new System.Drawing.Size(281, 51);
            this.topRightLabel.TabIndex = 27;
            this.topRightLabel.Text = "База данных";
            // 
            // applyFilterButton
            // 
            this.applyFilterButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.applyFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.applyFilterButton.Location = new System.Drawing.Point(109, 618);
            this.applyFilterButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.applyFilterButton.Name = "applyFilterButton";
            this.applyFilterButton.Size = new System.Drawing.Size(419, 73);
            this.applyFilterButton.TabIndex = 28;
            this.applyFilterButton.Text = "Применить фильтры";
            this.applyFilterButton.UseVisualStyleBackColor = false;
            this.applyFilterButton.Click += new System.EventHandler(this.ApplyFilterButton_Click);
            // 
            // filterPanel
            // 
            this.filterPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.filterPanel.Controls.Add(this.label1);
            this.filterPanel.Controls.Add(this.filterLogicTextBox);
            this.filterPanel.Controls.Add(this.filterLogicComboBox);
            this.filterPanel.Controls.Add(this.applyFilterButton);
            this.filterPanel.Controls.Add(this.addFilterButton);
            this.filterPanel.Controls.Add(this.flowLayoutPanel);
            this.filterPanel.Location = new System.Drawing.Point(107, 98);
            this.filterPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(636, 694);
            this.filterPanel.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(323, 556);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "Логика фильров:";
            // 
            // filterLogicTextBox
            // 
            this.filterLogicTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.filterLogicTextBox.Location = new System.Drawing.Point(445, 585);
            this.filterLogicTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filterLogicTextBox.Name = "filterLogicTextBox";
            this.filterLogicTextBox.Size = new System.Drawing.Size(52, 22);
            this.filterLogicTextBox.TabIndex = 30;
            this.filterLogicTextBox.Visible = false;
            // 
            // filterLogicComboBox
            // 
            this.filterLogicComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.filterLogicComboBox.FormattingEnabled = true;
            this.filterLogicComboBox.Items.AddRange(new object[] {
            "       \"И\"",
            "    \"ИЛИ\"",
            "СЧЁТЧИК"});
            this.filterLogicComboBox.Location = new System.Drawing.Point(328, 585);
            this.filterLogicComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filterLogicComboBox.Name = "filterLogicComboBox";
            this.filterLogicComboBox.Size = new System.Drawing.Size(108, 24);
            this.filterLogicComboBox.TabIndex = 29;
            this.filterLogicComboBox.SelectedIndexChanged += new System.EventHandler(this.FilterLogicComboBox_SelectedIndexChanged);
            // 
            // returnButton
            // 
            this.returnButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.returnButton.BackgroundImage = global::DBSorter.Properties.Resources.ReturnIcon;
            this.returnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.returnButton.Location = new System.Drawing.Point(15, 437);
            this.returnButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(85, 79);
            this.returnButton.TabIndex = 35;
            this.returnButton.UseVisualStyleBackColor = false;
            this.returnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // saveDBButton
            // 
            this.saveDBButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.saveDBButton.BackgroundImage = global::DBSorter.Properties.Resources.SaveDBIcon;
            this.saveDBButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveDBButton.Location = new System.Drawing.Point(15, 353);
            this.saveDBButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveDBButton.Name = "saveDBButton";
            this.saveDBButton.Size = new System.Drawing.Size(85, 79);
            this.saveDBButton.TabIndex = 34;
            this.saveDBButton.UseVisualStyleBackColor = false;
            this.saveDBButton.Click += new System.EventHandler(this.SaveDBButton_Click);
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuButton.BackgroundImage = global::DBSorter.Properties.Resources.MenuIcon;
            this.menuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F);
            this.menuButton.Location = new System.Drawing.Point(15, 98);
            this.menuButton.Margin = new System.Windows.Forms.Padding(4);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(85, 79);
            this.menuButton.TabIndex = 30;
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // hideFiltersButton
            // 
            this.hideFiltersButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.hideFiltersButton.BackgroundImage = global::DBSorter.Properties.Resources.HideFiltersIcon;
            this.hideFiltersButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hideFiltersButton.Location = new System.Drawing.Point(15, 183);
            this.hideFiltersButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hideFiltersButton.Name = "hideFiltersButton";
            this.hideFiltersButton.Size = new System.Drawing.Size(85, 79);
            this.hideFiltersButton.TabIndex = 33;
            this.hideFiltersButton.UseVisualStyleBackColor = false;
            this.hideFiltersButton.Click += new System.EventHandler(this.HideFiltersButton_Click);
            // 
            // changeTableButton
            // 
            this.changeTableButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.changeTableButton.BackgroundImage = global::DBSorter.Properties.Resources.OpenTableIcon;
            this.changeTableButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.changeTableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.2F);
            this.changeTableButton.Location = new System.Drawing.Point(16, 268);
            this.changeTableButton.Margin = new System.Windows.Forms.Padding(4);
            this.changeTableButton.Name = "changeTableButton";
            this.changeTableButton.Size = new System.Drawing.Size(85, 79);
            this.changeTableButton.TabIndex = 29;
            this.changeTableButton.UseVisualStyleBackColor = false;
            this.changeTableButton.Click += new System.EventHandler(this.ChangeTableButton_Click);
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.8F);
            this.loadingLabel.Location = new System.Drawing.Point(872, 363);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(520, 69);
            this.loadingLabel.TabIndex = 36;
            this.loadingLabel.Text = "ИДЁТ ЗАГРУЗКА";
            this.loadingLabel.Visible = false;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1540, 823);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.saveDBButton);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.hideFiltersButton);
            this.Controls.Add(this.changeTableButton);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.topRightLabel);
            this.Controls.Add(this.topLeftLabel);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button7);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindowForm";
            this.Text = "Сортировщик БД";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button addFilterButton;
        private FlowLayoutPanel flowLayoutPanel;
        private Label topLeftLabel;
        private Label topRightLabel;
        private Button applyFilterButton;
        private Button changeTableButton;
        private Button menuButton;
        private Panel filterPanel;
        private Button hideFiltersButton;
        private Button saveDBButton;
        private Button returnButton;
        private TextBox filterLogicTextBox;
        private ComboBox filterLogicComboBox;
        private Label label1;
        private Label loadingLabel;
    }
}

