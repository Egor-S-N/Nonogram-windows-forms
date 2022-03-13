using System;
using System.Windows.Forms;

namespace Kursovik_NONOGRAMM
{
    public partial class Form1 : Form
    {

        public int selector;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logic.RemoveLabels(this);
            Logic.RemoveButtons(this);
            Logic.RemoveCongratulationsLabel(this);
            Logic.ClearAnswer();

            Logic.Lcontrol = this;
            Logic.Choise();

            Logic.CreateButtons(Logic.Lcontrol);
            Logic.CreateLabels(Logic.Lcontrol);
        }

        
      
       
    }
}
