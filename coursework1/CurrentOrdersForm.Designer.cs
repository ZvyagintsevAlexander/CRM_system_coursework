namespace coursework1
{
    partial class CurrentOrdersForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finish_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseworkDataSet = new coursework1.courseworkDataSet();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ordersTableAdapter = new coursework1.courseworkDataSetTableAdapters.ordersTableAdapter();
            this.statusesTableAdapter = new coursework1.courseworkDataSetTableAdapters.statusesTableAdapter();
            this.ordered_dishesTableAdapter = new coursework1.courseworkDataSetTableAdapters.ordered_dishesTableAdapter();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseworkDataSet)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 1009);
            this.panel1.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(3, 432);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(328, 137);
            this.button4.TabIndex = 3;
            this.button4.Text = "Клиенты";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnOpenClientsForm);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(3, 289);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(328, 137);
            this.button3.TabIndex = 2;
            this.button3.Text = "Курьеры";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(3, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(328, 137);
            this.button2.TabIndex = 1;
            this.button2.Text = "История заказов";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnOpenOrderHistoryForm);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(328, 137);
            this.button1.TabIndex = 0;
            this.button1.Text = "Текущие заказы";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dataGridView3);
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Location = new System.Drawing.Point(1071, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(819, 451);
            this.panel3.TabIndex = 3;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(3, 176);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(450, 270);
            this.dataGridView3.TabIndex = 6;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.title,
            this.start_date,
            this.finish_date});
            this.dataGridView2.Location = new System.Drawing.Point(4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(449, 132);
            this.dataGridView2.TabIndex = 0;
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "Статус";
            this.title.MinimumWidth = 6;
            this.title.Name = "title";
            this.title.Width = 125;
            // 
            // start_date
            // 
            this.start_date.DataPropertyName = "start_date";
            this.start_date.HeaderText = "Дата начала";
            this.start_date.MinimumWidth = 6;
            this.start_date.Name = "start_date";
            this.start_date.Width = 135;
            // 
            // finish_date
            // 
            this.finish_date.DataPropertyName = "finish_date";
            this.finish_date.HeaderText = "Дата завершения";
            this.finish_date.MinimumWidth = 6;
            this.finish_date.Name = "finish_date";
            this.finish_date.Width = 135;
            // 
            // courseworkDataSet
            // 
            this.courseworkDataSet.DataSetName = "courseworkDataSet";
            this.courseworkDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button9);
            this.panel4.Controls.Add(this.btnDeleteOrder);
            this.panel4.Controls.Add(this.btnEditOrder);
            this.panel4.Controls.Add(this.btnCreateOrder);
            this.panel4.Location = new System.Drawing.Point(1071, 473);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(819, 548);
            this.panel4.TabIndex = 4;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(46, 163);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(184, 57);
            this.button9.TabIndex = 3;
            this.button9.Text = "Отменить заказ";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(269, 163);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(184, 57);
            this.btnDeleteOrder.TabIndex = 2;
            this.btnDeleteOrder.Text = "Удалить заказ";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Location = new System.Drawing.Point(269, 51);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(184, 57);
            this.btnEditOrder.TabIndex = 1;
            this.btnEditOrder.Text = "Изменить заказ";
            this.btnEditOrder.UseVisualStyleBackColor = true;
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(46, 51);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(184, 57);
            this.btnCreateOrder.TabIndex = 0;
            this.btnCreateOrder.Text = "Добавить заказ";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(355, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(710, 782);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_SelectionChanged);
            // 
            // ordersTableAdapter
            // 
            this.ordersTableAdapter.ClearBeforeFill = true;
            // 
            // statusesTableAdapter
            // 
            this.statusesTableAdapter.ClearBeforeFill = true;
            // 
            // ordered_dishesTableAdapter
            // 
            this.ordered_dishesTableAdapter.ClearBeforeFill = true;
            // 
            // CurrentOrdersForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(1918, 1028);
            this.Name = "CurrentOrdersForm";
            this.RightToLeftLayout = true;
            this.Text = "OrdersForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.courseworkDataSet)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private courseworkDataSetTableAdapters.ordersTableAdapter ordersTableAdapter;
        private courseworkDataSetTableAdapters.statusesTableAdapter statusesTableAdapter;
        private courseworkDataSetTableAdapters.ordered_dishesTableAdapter ordered_dishesTableAdapter;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Button button9;
        private courseworkDataSet courseworkDataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn finish_date;
    }
}