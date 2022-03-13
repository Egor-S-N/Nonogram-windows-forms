using System;
using System.Windows.Forms;

namespace Kursovik_NONOGRAMM
{
    public partial class ChoiseLevel : Form
    {
        public ChoiseLevel()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {

            Logic.selector = 1;
            Logic.value = rnd.Next(0,10);
            Form1 form1 = new Form1();
            this.Visible = false;
            this.Close();
            form1.ShowDialog();
            this.Visible = true;
            form1.Dispose();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            Logic.selector = 2;
            Logic.value = rnd.Next(10,20);
            Form1 form1 = new Form1();
            this.Visible = false;
            this.Close();
            form1.ShowDialog();
            this.Visible = true;
            form1.Dispose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Logic.selector = 3;
            Logic.value = rnd.Next(20, 30);
            Form1 form1 = new Form1();
            this.Visible = false;
            this.Close();
            form1.ShowDialog();
            this.Visible = true;
            form1.Dispose();
        }

    }
}
