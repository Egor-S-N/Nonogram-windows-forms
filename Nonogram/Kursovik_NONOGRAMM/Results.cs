using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace Kursovik_NONOGRAMM
{
    public partial class Results : Form
    {
        public Results()
        {
            InitializeComponent();
        }

        private void Results_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("..\\..\\Results.txt", Encoding.GetEncoding(1251)))
            {
                richTextBox1.Text = sr.ReadToEnd();
            }
        }
    }
}
