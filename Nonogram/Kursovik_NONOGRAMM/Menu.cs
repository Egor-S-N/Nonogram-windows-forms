using System;
using System.Windows.Forms;

namespace Kursovik_NONOGRAMM
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Start_game(object sender, EventArgs e)
        {
            ChoiseLevel choiseLevel = new ChoiseLevel();
            this.Visible = false;
            choiseLevel.ShowDialog();
            this.Visible = true;
            choiseLevel.Dispose();
            
        }

        private void Open_description(object sender, EventArgs e)
        {
            Description description= new Description();
            this.Visible = false;
            description.ShowDialog();
            this.Visible = true;
            description.Dispose();
        }


        private void Exit_game(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Results results = new Results();
            this.Visible = false;
            results.ShowDialog();
            this.Visible = true;
            results.Dispose();
        }

       
    }
}
