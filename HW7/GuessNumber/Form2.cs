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
    public partial class Form2 : Form
    {
        private MySender ms;
        Manager manager = new Manager();
        public Form2(MySender sender)
        {
            InitializeComponent();
            ms = sender;
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            Data.Value = tbGuess.Text;
            //ms(tbGuess.Text);
            manager.Check();
            ms(tbGuess.Text);
            this.Close();
        }
    }
}
