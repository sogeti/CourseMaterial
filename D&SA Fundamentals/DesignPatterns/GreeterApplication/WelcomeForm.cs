using System;
using System.Windows.Forms;

namespace GreeterApplication
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "Dutch";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = new GreetingEngine().SayHello(comboBox1.SelectedItem.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = new GreetingEngine().SayGoodbye(comboBox1.SelectedItem.ToString());
        }
    }
}
