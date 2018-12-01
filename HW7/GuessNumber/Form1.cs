using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber_HW7
{
    public partial class Form1 : Form
    {
        Manager manager = null;
        //Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            //int Number = manager
            manager = new Manager();
            lbNumber.Text = manager.Number.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(new MySender(func));
            f2.ShowDialog();
        }

        void func (string param)
        {
            lbGuess.Text = param;
            lbWhat.Text = Data.What;
        }
    }
}
