using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace coursework1
{
    public partial class CurrentOrdersForm : Form
    {
        public CurrentOrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'courseworkDataSet.statuses' table. You can move, or remove it, as needed.
            this.statusesTableAdapter.Fill(this.courseworkDataSet.statuses);
            // TODO: This line of code loads data into the 'courseworkDataSet.orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.courseworkDataSet.orders);
            // TODO: This line of code loads data into the 'courseworkDataSet.statuses' table. You can move, or remove it, as needed.
            this.statusesTableAdapter.Fill(this.courseworkDataSet.statuses);
            // TODO: This line of code loads data into the 'courseworkDataSet.orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.courseworkDataSet.orders);
            // TODO: This line of code loads data into the 'courseworkDataSet.orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.courseworkDataSet.orders);
            // TODO: This line of code loads data into the 'courseworkDataSet.statuses' table. You can move, or remove it, as needed.
            this.statusesTableAdapter.Fill(this.courseworkDataSet.statuses);
            // TODO: This line of code loads data into the 'courseworkDataSet.orders' table. You can move, or remove it, as needed.
            this.ordersTableAdapter.Fill(this.courseworkDataSet.orders);



            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True")) 
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT dbo.orders.id AS 'Код заказа', dbo.clients.address AS 'Адрес', dbo.orders.total_cost AS 'Общая стоимость', dbo.clients.phone AS 'Телефон клиента', " +
                    "dbo.couriers.phone AS 'Телефон курьера', dbo.statuses.title AS 'Статус' \r\n" +
                "FROM [dbo].[orders] \r\nINNER JOIN dbo.clients ON dbo.orders.client_id = dbo.clients.id\r\n" +
                "INNER JOIN dbo.couriers ON dbo.orders.courier_id = dbo.couriers.id \r\nINNER JOIN dbo.statuses ON dbo.orders.id = dbo.statuses.order_id \r\n" +
                "WHERE dbo.statuses.title != 'Отменен' AND dbo.statuses.title != 'Выполнен' \r\nAND dbo.statuses.id = (SELECT MAX(id) FROM dbo.statuses WHERE order_id = dbo.orders.id)", con);

                cmd.ExecuteNonQuery();
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

                cmd = new SqlCommand("SELECT dbo.menu.title AS 'Название блюда', dbo.ordered_dishes.quantity AS 'Количество'\r\n" +
                                                "FROM dbo.menu INNER JOIN\r\n dbo.ordered_dishes ON dbo.menu.id = dbo.ordered_dishes.menu_id " +
                                                "WHERE (dbo.ordered_dishes.order_id = @id)", con);
                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
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

        private void dataGridView1_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            int selectedOrderId = (int)dataGridView1.CurrentRow.Cells[0].Value;

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
                cmd.Parameters.AddWithValue("@id", selectedOrderId);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dt.Columns.Add("Стоимость позиции", typeof(decimal));
                dataGridView3.DataSource = dt;

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    cmd = new SqlCommand("SELECT [cost]\r\n  FROM [dbo].[menu]\r\n  WHERE dbo.menu.title = @title", con);
                    cmd.Parameters.AddWithValue("@title", (string)dataGridView3.Rows[i].Cells[0].Value);

                    decimal position_cost = (decimal)cmd.ExecuteScalar();
                    dataGridView3.Rows[i].Cells[2].Value = position_cost;

                }

                dataGridView3.DataSource = dt;
            }
        }

        public int a = 0;

        public void btnCreateOrder_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework; Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[orders]
                                               ([courier_id]
                                               ,[client_id])
                                         VALUES
                                               (0
                                               , 15)", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT MAX(id) FROM dbo.orders", con);
                int order_id = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("INSERT INTO [dbo].[statuses]\r\n           ([title]\r\n           ,[start_date] ,[order_id])\r\n     VALUES\r\n           " +
                    "('Обработка'\r\n   ,@start_date ,@order_id)", con);
                cmd.Parameters.AddWithValue("@start_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@order_id", order_id);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT dbo.orders.id AS 'Код заказа', dbo.clients.address AS 'Адрес', dbo.orders.total_cost AS 'Общая стоимость', dbo.clients.phone AS 'Телефон клиента', dbo.couriers.phone AS 'Телефон курьера', dbo.statuses.title AS 'Статус' \r\n" +
                "FROM [dbo].[orders] \r\nINNER JOIN dbo.clients ON dbo.orders.client_id = dbo.clients.id\r\n" +
                "INNER JOIN dbo.couriers ON dbo.orders.courier_id = dbo.couriers.id \r\nINNER JOIN dbo.statuses ON dbo.orders.id = dbo.statuses.order_id \r\n" +
                "WHERE dbo.statuses.title != 'Отменен' AND dbo.statuses.title != 'Выполнен' \r\nAND dbo.statuses.id = (SELECT MAX(id) FROM dbo.statuses WHERE order_id = dbo.orders.id)", con);

                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }

            CreateOrderForm createOrderForm = new CreateOrderForm((int)dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value);
            createOrderForm.ShowDialog();

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework; Integrated Security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT dbo.orders.id AS 'Код заказа', dbo.clients.address AS 'Адрес', dbo.orders.total_cost AS 'Общая стоимость', dbo.clients.phone AS 'Телефон клиента', dbo.couriers.phone AS 'Телефон курьера', dbo.statuses.title AS 'Статус' \r\n" +
                "FROM [dbo].[orders] \r\nINNER JOIN dbo.clients ON dbo.orders.client_id = dbo.clients.id\r\n" +
                "INNER JOIN dbo.couriers ON dbo.orders.courier_id = dbo.couriers.id \r\nINNER JOIN dbo.statuses ON dbo.orders.id = dbo.statuses.order_id \r\n" +
                "WHERE dbo.statuses.title != 'Отменен' AND dbo.statuses.title != 'Выполнен' \r\nAND dbo.statuses.id = (SELECT MAX(id) FROM dbo.statuses WHERE order_id = dbo.orders.id)", con);

                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            EditOrderForm editOrderForm = new EditOrderForm((int)dataGridView1.CurrentRow.Cells[0].Value);
            editOrderForm.ShowDialog();

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT dbo.orders.id AS 'Код заказа', dbo.clients.address AS 'Адрес', dbo.orders.total_cost AS 'Общая стоимость', dbo.clients.phone AS 'Телефон клиента', dbo.couriers.phone AS 'Телефон курьера', dbo.statuses.title AS 'Статус' \r\n" +
                "FROM [dbo].[orders] \r\nINNER JOIN dbo.clients ON dbo.orders.client_id = dbo.clients.id\r\n" +
                "INNER JOIN dbo.couriers ON dbo.orders.courier_id = dbo.couriers.id \r\nINNER JOIN dbo.statuses ON dbo.orders.id = dbo.statuses.order_id \r\n" +
                "WHERE dbo.statuses.title != 'Отменен' AND dbo.statuses.title != 'Выполнен' \r\nAND dbo.statuses.id = (SELECT MAX(id) FROM dbo.statuses WHERE order_id = dbo.orders.id)", con);

                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }


        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True"))
            {
                con.Open();
                var cmd = new SqlCommand(@"DELETE FROM [dbo].[orders] WHERE ([id] = @id)", con);
                cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT dbo.orders.id AS 'Код заказа', dbo.clients.address AS 'Адрес', dbo.orders.total_cost AS 'Общая стоимость', dbo.clients.phone AS 'Телефон клиента', dbo.couriers.phone AS 'Телефон курьера', dbo.statuses.title AS 'Статус' \r\n" +
                "FROM [dbo].[orders] \r\nINNER JOIN dbo.clients ON dbo.orders.client_id = dbo.clients.id\r\n" +
                "INNER JOIN dbo.couriers ON dbo.orders.courier_id = dbo.couriers.id \r\nINNER JOIN dbo.statuses ON dbo.orders.id = dbo.statuses.order_id \r\n" +
                "WHERE dbo.statuses.title != 'Отменен' AND dbo.statuses.title != 'Выполнен' \r\nAND dbo.statuses.id = (SELECT MAX(id) FROM dbo.statuses WHERE order_id = dbo.orders.id)", con);

                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }


        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            int selectedOrderId = (int)dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows.RemoveAt(selectedOrderId);
        }

        private void btnOpenClientsForm(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();
            clientsForm.ShowDialog();
            this.Close();
        }

        private void btnOpenOrderHistoryForm(object sender, EventArgs e)
        {
            OrderHistoryForm orderHistoryForm = new OrderHistoryForm();
            orderHistoryForm.ShowDialog();
            this.Close();
        }
    }
}
