namespace WinFormsApp2
{
    partial class StorageWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.storage_btn = new System.Windows.Forms.Button();
            this.otgruzka_btn = new System.Windows.Forms.Button();
            this.priemka_btn = new System.Windows.Forms.Button();
            this.PriemkaData = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dayLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.OtgruzkaData = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.StorageInfo = new System.Windows.Forms.DataGridView();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PriemkaData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtgruzkaData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StorageInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.storage_btn);
            this.splitContainer1.Panel1.Controls.Add(this.otgruzka_btn);
            this.splitContainer1.Panel1.Controls.Add(this.priemka_btn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button6);
            this.splitContainer1.Panel2.Controls.Add(this.PriemkaData);
            this.splitContainer1.Panel2.Controls.Add(this.button5);
            this.splitContainer1.Panel2.Controls.Add(this.button4);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.dayLabel);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.OtgruzkaData);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.StorageInfo);
            this.splitContainer1.Size = new System.Drawing.Size(1064, 681);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.TabIndex = 0;
            // 
            // storage_btn
            // 
            this.storage_btn.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.storage_btn.Location = new System.Drawing.Point(12, 12);
            this.storage_btn.Name = "storage_btn";
            this.storage_btn.Size = new System.Drawing.Size(135, 31);
            this.storage_btn.TabIndex = 2;
            this.storage_btn.Text = "Склад";
            this.storage_btn.UseVisualStyleBackColor = true;
            this.storage_btn.Click += new System.EventHandler(this.storage_btn_Click);
            // 
            // otgruzka_btn
            // 
            this.otgruzka_btn.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.otgruzka_btn.Location = new System.Drawing.Point(12, 49);
            this.otgruzka_btn.Name = "otgruzka_btn";
            this.otgruzka_btn.Size = new System.Drawing.Size(135, 31);
            this.otgruzka_btn.TabIndex = 1;
            this.otgruzka_btn.Text = "Отгрузка";
            this.otgruzka_btn.UseVisualStyleBackColor = true;
            this.otgruzka_btn.Click += new System.EventHandler(this.otgruzka_btn_Click);
            // 
            // priemka_btn
            // 
            this.priemka_btn.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.priemka_btn.Location = new System.Drawing.Point(12, 86);
            this.priemka_btn.Name = "priemka_btn";
            this.priemka_btn.Size = new System.Drawing.Size(135, 31);
            this.priemka_btn.TabIndex = 0;
            this.priemka_btn.Text = "Приемка";
            this.priemka_btn.UseVisualStyleBackColor = true;
            this.priemka_btn.Click += new System.EventHandler(this.priemka_btn_Click);
            // 
            // PriemkaData
            // 
            this.PriemkaData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.PriemkaData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.PriemkaData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PriemkaData.Location = new System.Drawing.Point(25, 35);
            this.PriemkaData.Name = "PriemkaData";
            this.PriemkaData.RowTemplate.Height = 25;
            this.PriemkaData.Size = new System.Drawing.Size(802, 426);
            this.PriemkaData.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(340, 467);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(99, 74);
            this.button5.TabIndex = 9;
            this.button5.Text = "Склад получает продукты от поставщика";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(445, 467);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 74);
            this.button4.TabIndex = 8;
            this.button4.Text = "Следующий день";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(235, 467);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 74);
            this.button3.TabIndex = 7;
            this.button3.Text = "Склад отсылает запросы поставщику";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dayLabel
            // 
            this.dayLabel.AutoSize = true;
            this.dayLabel.Location = new System.Drawing.Point(830, 12);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(12, 15);
            this.dayLabel.TabIndex = 6;
            this.dayLabel.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(787, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "День:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(130, 467);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 74);
            this.button2.TabIndex = 4;
            this.button2.Text = "Склад обрабатывает запросы";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 467);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 74);
            this.button1.TabIndex = 3;
            this.button1.Text = "Магазины отсылают запросы";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OtgruzkaData
            // 
            this.OtgruzkaData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.OtgruzkaData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.OtgruzkaData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OtgruzkaData.Location = new System.Drawing.Point(25, 35);
            this.OtgruzkaData.Name = "OtgruzkaData";
            this.OtgruzkaData.RowTemplate.Height = 25;
            this.OtgruzkaData.Size = new System.Drawing.Size(802, 426);
            this.OtgruzkaData.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Информация по складу";
            // 
            // StorageInfo
            // 
            this.StorageInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.StorageInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.StorageInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StorageInfo.Location = new System.Drawing.Point(25, 35);
            this.StorageInfo.Name = "StorageInfo";
            this.StorageInfo.RowTemplate.Height = 25;
            this.StorageInfo.Size = new System.Drawing.Size(802, 426);
            this.StorageInfo.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(138, 583);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(91, 37);
            this.button6.TabIndex = 11;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // StorageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.splitContainer1);
            this.Name = "StorageWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PriemkaData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OtgruzkaData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StorageInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Button storage_btn;
        private Button otgruzka_btn;
        private Button priemka_btn;
        private Label label1;
        private DataGridView StorageInfo;
        private DataGridView OtgruzkaData;
        private Button button1;
        private Button button2;
        private Label dayLabel;
        private Label label2;
        private Button button4;
        private Button button3;
        private Button button5;
        private DataGridView PriemkaData;
        private Button button6;
    }
}