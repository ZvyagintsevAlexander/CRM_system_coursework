using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework1
{
    public partial class OrderHistoryForm : Form
    {
        public OrderHistoryForm()
        {
            InitializeComponent();
        }

        private void btnOpenClientsForm_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();
            this.Close();
            clientsForm.ShowDialog();
        }

        private void btnOpenCurrentOrdersForm_Click(object sender, EventArgs e)
        {
            CurrentOrdersForm currentOrdersForm = new CurrentOrdersForm();
            this.Close();
            currentOrdersForm.ShowDialog();
        }

        private void OrderHistoryForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'courseworkDataSet.orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.courseworkDataSet.orders);
            // TODO: This line of code loads data into the 'courseworkDataSet.orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.courseworkDataSet.orders);

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework; Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.orders.id AS 'Код заказа'\r\n      ,[total_cost] AS 'Общая стоимость'\r\n      ,[courier_id] AS 'Код курьера'\r\n      ,[client_id] AS 'Код клиента' ,dbo.statuses.title AS 'Статус'\r\n  " +
                    "FROM [dbo].[orders] INNER JOIN dbo.statuses ON dbo.orders.id = dbo.statuses.order_id WHERE dbo.statuses.title = 'Выполнен' OR dbo.statuses.title = 'Отменен'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                cmd = new SqlCommand("SELECT [title]\r\n      ,[start_date]\r\n      ,[finish_date]\r\n   FROM [dbo].[statuses]\r\n  WHERE dbo.statuses.order_id = @order_id", con);
                cmd.Parameters.AddWithValue("@order_id", dataGridView1.CurrentRow.Cells[0].Value);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;

                cmd = new SqlCommand("SELECT dbo.menu.title AS 'Название блюда', dbo.ordered_dishes.quantity AS 'Количество'" +
                                "FROM dbo.menu " +
                                "INNER JOIN dbo.ordered_dishes ON dbo.menu.id = dbo.ordered_dishes.menu_id " +
                                "WHERE dbo.ordered_dishes.order_id = @id", con);
                cmd.Parameters.AddWithValue("@id", (int)dataGridView1.CurrentRow.Cells[0].Value);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Add("Стоимость позиции", typeof(decimal));
                dataGridView3.DataSource = dt;

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    cmd = new SqlCommand("SELECT [cost]\r\n  FROM [dbo].[menu]\r\n  WHERE dbo.menu.title = @title", con);
                    cmd.Parameters.AddWithValue("@title", (string)dataGridView3.Rows[i].Cells[0].Value);

                    decimal position_cost = (decimal)cmd.ExecuteScalar() * (int)dataGridView3.Rows[i].Cells[1].Value;
                    dataGridView3.Rows[i].Cells[2].Value = position_cost;

                }

                dataGridView3.DataSource = dt;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;

            string columnNameToSearch = "";

            if (comboBox1.Text == "Код заказа")
            {
                columnNameToSearch = comboBox1.Text;
            }

            else if (comboBox1.Text == "Общая стоимость")
            {
                columnNameToSearch = comboBox1.Text;
            }

            else if (comboBox1.Text == "Код клиента")
            {
                columnNameToSearch = comboBox1.Text;
            }

            else if (comboBox1.Text == "Код курьера")
            {
                columnNameToSearch = comboBox1.Text;
            }

            else if (comboBox1.Text == "Статус")
            {
                columnNameToSearch = comboBox1.Text;
            }

            if (columnNameToSearch != "")
            {
                bs.Filter = String.Format("CONVERT([{0}], System.String) like '%{1}%'",
                                             columnNameToSearch, textBox1.Text.Trim());
                dataGridView1.DataSource = bs;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT [title]\r\n      ,[start_date]\r\n      ,[finish_date]\r\n   FROM [dbo].[statuses]\r\n  WHERE dbo.statuses.order_id = @order_id", con);
                cmd.Parameters.AddWithValue("@order_id", dataGridView1.CurrentRow.Cells[0].Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;

                cmd = new SqlCommand("SELECT dbo.menu.title AS 'Название блюда', dbo.ordered_dishes.quantity AS 'Количество'" +
                "FROM dbo.menu " +
                "INNER JOIN dbo.ordered_dishes ON dbo.menu.id = dbo.ordered_dishes.menu_id " +
                "WHERE dbo.ordered_dishes.order_id = @id", con);
                cmd.Parameters.AddWithValue("@id", (int)dataGridView1.CurrentRow.Cells[0].Value);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Add("Стоимость позиции", typeof(decimal));
                dataGridView3.DataSource = dt;

                for (int i = 0; i < dt.Rows.Count; i++)
                {


                    cmd = new SqlCommand("SELECT [cost]\r\n  FROM [dbo].[menu]\r\n  WHERE dbo.menu.title = @title", con);
                    cmd.Parameters.AddWithValue("@title", (string)dataGridView3.Rows[i].Cells[0].Value);

                    decimal position_cost = (decimal)cmd.ExecuteScalar() * (int)dataGridView3.Rows[i].Cells[1].Value;
                    dataGridView3.Rows[i].Cells[2].Value = position_cost;

                }

                dataGridView3.DataSource = dt;


            }
        }

    }
}
