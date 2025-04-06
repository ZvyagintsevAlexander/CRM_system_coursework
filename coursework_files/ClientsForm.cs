using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework1
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
        }

        private void btnOpenCurrentOrders(object sender, EventArgs e)
        {
            CurrentOrdersForm ordersForm = new CurrentOrdersForm();
            this.Close();
            ordersForm.ShowDialog();
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'courseworkDataSet.clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.courseworkDataSet.clients);
            // TODO: This line of code loads data into the 'courseworkDataSet.clients' table. You can move, or remove it, as needed.
            this.clientsTableAdapter.Fill(this.courseworkDataSet.clients);

        }

        private void btnOpenOrderHistoryForm(object sender, EventArgs e)
        {
            OrderHistoryForm orderHistoryForm = new OrderHistoryForm();
            this.Close();
            orderHistoryForm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;

            string columnNameToSearch = "";

            if (comboBox1.Text == "Код клиента") 
            {
                columnNameToSearch = "id";
            }

            else if (comboBox1.Text == "Имя") 
            {
                columnNameToSearch = "name";
            }

            else if (comboBox1.Text == "Адрес")
            {
                columnNameToSearch = "address";
            }

            else if (comboBox1.Text == "Номер телефона")
            {
                columnNameToSearch = "phone";
            }

            else if (comboBox1.Text == "Электронная почта")
            {
                columnNameToSearch = "email";
            }

            if (columnNameToSearch != "") 
            {
                bs.Filter = String.Format("CONVERT([{0}], System.String) like '%{1}%'",
                                             columnNameToSearch, textBox1.Text.Trim());
                dataGridView1.DataSource = bs;
            }
        }
    }
}
