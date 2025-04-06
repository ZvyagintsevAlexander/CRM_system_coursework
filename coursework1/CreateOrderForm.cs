using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace coursework1
{
    public partial class CreateOrderForm : Form
    {
        public int newOrderId;
        public CreateOrderForm(int id)
        {
            newOrderId = id;
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [id]\r\n  FROM [dbo].[menu]\r\n  WHERE dbo.menu.title = @title", con);
                    cmd.Parameters.AddWithValue("@title", (string)dataGridView1.Rows[i].Cells[0].Value);
                    int menu_id = (int)cmd.ExecuteScalar();

                    cmd = new SqlCommand("INSERT INTO [dbo].[ordered_dishes]\r\n           ([menu_id]\r\n           ,[quantity]\r\n           " +
                        ",[order_id])\r\n     VALUES\r\n           (@menu_id\r\n           ,@quantity\r\n           ,@order_id)", con);
                    cmd.Parameters.AddWithValue("@order_id", newOrderId);
                    cmd.Parameters.AddWithValue("@menu_id", menu_id);
                    cmd.Parameters.AddWithValue("@quantity", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.ExecuteNonQuery();
                }
            }

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM [dbo].[clients] WHERE dbo.clients.address = @address AND dbo.clients.phone = @phone", con);
                cmd.Parameters.AddWithValue("@address", txtBoxAddress.Text);
                cmd.Parameters.AddWithValue("@phone", txtBoxPhone.Text);

                int clientIsExist = (int)cmd.ExecuteScalar();

                if (clientIsExist == 0)
                {
                    cmd = new SqlCommand("INSERT INTO [dbo].[clients]\r\n           ([name]\r\n           ,[address]\r\n           ,[phone]\r\n           ,[email])\r\n     " +
                                            "VALUES\r\n           (@name\r\n           ,@address\r\n           ,@phone\r\n           ,@email)", con);

                    cmd.Parameters.AddWithValue("@name", txtBoxName.Text);
                    cmd.Parameters.AddWithValue("@address", txtBoxAddress.Text);
                    cmd.Parameters.AddWithValue("@phone", txtBoxPhone.Text);
                    cmd.Parameters.AddWithValue("@email", txtBoxEmail.Text);
                    cmd.ExecuteNonQuery();
                }


                cmd = new SqlCommand("SELECT [id]\r\n  FROM [dbo].[clients]  WHERE dbo.clients.address = @address AND dbo.clients.phone = @phone", con);
                cmd.Parameters.AddWithValue("@address", txtBoxAddress.Text);
                cmd.Parameters.AddWithValue("@phone", txtBoxPhone.Text);

                int client_id = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("UPDATE [dbo].[orders]\r\n   SET [client_id] = @client_id WHERE dbo.orders.id = @id", con);
                cmd.Parameters.AddWithValue("@client_id", client_id);
                cmd.Parameters.AddWithValue("@id", newOrderId);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE [dbo].[orders]\r\n   SET [total_cost] = @total_cost\r\nWHERE dbo.orders.id = @id", con);
                cmd.Parameters.AddWithValue("@total_cost", decimal.Parse(label7.Text));
                cmd.Parameters.AddWithValue("@id", newOrderId);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE [dbo].[statuses]\r\n   SET [finish_date] = @finish_date\r\n WHERE dbo.statuses.order_id = @order_id", con);
                cmd.Parameters.AddWithValue("@finish_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@order_id", newOrderId);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT [id]\r\n  FROM [dbo].[couriers]\r\n  WHERE dbo.couriers.name = @name", con);
                cmd.Parameters.AddWithValue("@name", comboBox1.Text);
                int courier_id = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("UPDATE [dbo].[orders]\r\n   SET [courier_id] = @courier_id WHERE dbo.orders.id = @id", con);
                cmd.Parameters.AddWithValue("@id", newOrderId);
                cmd.Parameters.AddWithValue("@courier_id", courier_id);
                cmd.ExecuteNonQuery();

                if (comboBox1.Text != "Не назначен")
                {
                    cmd = new SqlCommand("UPDATE [dbo].[couriers]\r\n   SET [status] = @status\r\n WHERE dbo.couriers.name = @name", con);
                    cmd.Parameters.AddWithValue("@status", "Занят");
                    cmd.Parameters.AddWithValue("@name", comboBox1.Text);
                    cmd.ExecuteNonQuery();
                }
            }

            this.Close();
        }

        private void CreateOrderMenuForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            comboBox1.Text = "Не назначен";
            this.ordered_dishesTableAdapter.Fill(this.courseworkDataSet.ordered_dishes);

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [name]\r\n  FROM [dbo].[couriers]\r\n  WHERE dbo.couriers.status = @status", con);
                cmd.Parameters.AddWithValue("@status", "Свободен");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["name"].ToString());
                }
                reader.Close();

                cmd = new SqlCommand("SELECT [title] AS 'Название блюда'\r\n  FROM [dbo].[menu] WHERE dbo.menu.title != ''", con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            btnAccept.Enabled = false;


        }

        private void btnChooseDish(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }

            if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected)
            {
                dataGridView1.Rows.Add();
            }

/*            dataGridView1.CurrentRow.Cells[0].Value = (sender as Button).Text;
            dataGridView1.CurrentRow.Cells[1].Value = 1;*/


            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [cost]\r\n  FROM [dbo].[menu]\r\n  WHERE dbo.menu.title = @title", con);
                cmd.Parameters.AddWithValue("@title", (string)dataGridView1.CurrentRow.Cells[0].Value);

                decimal position_cost = (decimal)cmd.ExecuteScalar() * (int)dataGridView1.CurrentRow.Cells[1].Value;
                dataGridView1.CurrentRow.Cells[2].Value = position_cost;
            }

            decimal total_cost = 0;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                total_cost += (decimal)dataGridView1.Rows[i].Cells[2].Value;
            }

            this.ordered_dishesTableAdapter.Fill(this.courseworkDataSet.ordered_dishes);

            label7.Text = total_cost.ToString();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));

            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count != 1)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                this.ordered_dishesTableAdapter.Fill(this.courseworkDataSet.ordered_dishes);

                decimal total_cost = 0;

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    total_cost += (decimal)dataGridView1.Rows[i].Cells[2].Value;
                }

                label7.Text = total_cost.ToString();

                this.Refresh();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[orders]\r\n      WHERE dbo.orders.id = @id", con);
                cmd.Parameters.AddWithValue("@id", newOrderId);
                cmd.ExecuteNonQuery();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[1].Value != null) 
            {
                dataGridView1.CurrentRow.Cells[1].Value = (int)dataGridView1.CurrentRow.Cells[1].Value + 1;

                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT [cost]\r\n  FROM [dbo].[menu]\r\n  WHERE dbo.menu.title = @title", con);
                    cmd.Parameters.AddWithValue("@title", (string)dataGridView1.CurrentRow.Cells[0].Value);

                    decimal position_cost = (decimal)cmd.ExecuteScalar() * (int)dataGridView1.CurrentRow.Cells[1].Value;
                    dataGridView1.CurrentRow.Cells[2].Value = position_cost;
                }

                this.ordered_dishesTableAdapter.Fill(this.courseworkDataSet.ordered_dishes);

                decimal total_cost = 0;

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    total_cost += (decimal)dataGridView1.Rows[i].Cells[2].Value;
                }

                label7.Text = total_cost.ToString();

                this.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[1].Value != null)
            {
                if ((int)dataGridView1.CurrentRow.Cells[1].Value == 1) 
                {
                    if (dataGridView1.Rows.Count != 1)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        this.ordered_dishesTableAdapter.Fill(this.courseworkDataSet.ordered_dishes);

                        decimal total_cost = 0;

                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            total_cost += (decimal)dataGridView1.Rows[i].Cells[2].Value;
                        }

                        label7.Text = total_cost.ToString();

                        this.Refresh();
                    }
                }

                else 
                {
                    dataGridView1.CurrentRow.Cells[1].Value = (int)dataGridView1.CurrentRow.Cells[1].Value - 1;


                    using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True"))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SELECT [cost]\r\n  FROM [dbo].[menu]\r\n  WHERE dbo.menu.title = @title", con);
                        cmd.Parameters.AddWithValue("@title", (string)dataGridView1.CurrentRow.Cells[0].Value);

                        decimal position_cost = (decimal)cmd.ExecuteScalar() * (int)dataGridView1.CurrentRow.Cells[1].Value;
                        dataGridView1.CurrentRow.Cells[2].Value = position_cost;
                    }

                    this.ordered_dishesTableAdapter.Fill(this.courseworkDataSet.ordered_dishes);

                    decimal total_cost = 0;

                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        total_cost += (decimal)dataGridView1.Rows[i].Cells[2].Value;
                    }

                    label7.Text = total_cost.ToString();

                    this.Refresh();
                }

            }
        }

        private void txtBoxPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxPhone.Text != "" && txtBoxAddress.Text != "") 
            {
                btnAccept.Enabled = true;
            }
            else { btnAccept.Enabled = false; }
        }

        private void txtBoxAddress_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxPhone.Text != "" && txtBoxAddress.Text != "")
            {
                btnAccept.Enabled = true;
            }
            else { btnAccept.Enabled = false; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView2.DataSource;
            string filterString = textBox1.Text;
            bs.Filter = $"[Название блюда] LIKE '%{filterString}%'";
            dataGridView2.DataSource = bs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dataGridView2.CurrentCell.Value;
            dataGridView1.CurrentRow.Cells[1].Value = 1;

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=coursework;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT [cost]\r\n  FROM [dbo].[menu]\r\n  WHERE dbo.menu.title = @title", con);
                cmd.Parameters.AddWithValue("@title", (string)dataGridView1.CurrentRow.Cells[0].Value);

                decimal position_cost = (decimal)cmd.ExecuteScalar() * (int)dataGridView1.CurrentRow.Cells[1].Value;
                dataGridView1.CurrentRow.Cells[2].Value = position_cost;
            }

            decimal total_cost = 0;

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                total_cost += (decimal)dataGridView1.Rows[i].Cells[2].Value;
            }

            this.ordered_dishesTableAdapter.Fill(this.courseworkDataSet.ordered_dishes);

            label7.Text = total_cost.ToString();

            if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected)
            {
                dataGridView1.Rows.Add();
            }
        }
    }
}
