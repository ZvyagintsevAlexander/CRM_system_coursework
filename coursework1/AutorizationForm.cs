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
    public partial class AutorizationForm : Form
    {
        public AutorizationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "login" && textBox2.Text == "1234")
            {
                CurrentOrdersForm ordersForm = new CurrentOrdersForm();
                this.Hide();
                ordersForm.Show();
            }
            else 
            {
                AutorizationFailedForm autorizationFailedForm = new AutorizationFailedForm();
                autorizationFailedForm.Show();
            }
        }
    }
}
