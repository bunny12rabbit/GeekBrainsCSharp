using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7
{
    public partial class Form1 : Form
    {
        Udvoitel udvoitel=null;
        Random rnd = new Random();
        bool isFirst = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Уходите, так быстро? :(","Выход",MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)  this.Close();
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void UpdateInfo()
        {
            lblCurrent.Text = udvoitel?.Current.ToString();
            tbFinish.Text = udvoitel?.Finish.ToString();
            lbCount.Text = udvoitel?.Counter.ToString();
            if (udvoitel?.Current == udvoitel?.Finish)
            {
                if (MessageBox.Show("Поздравляем! Вы выиграли!!! :р", "Победа!!!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk) == DialogResult.Retry)
                    NewGame();
                else gbGame.Enabled = false;
            }
        }

        private void NewGame()
        {
            udvoitel = new Udvoitel(rnd.Next(2, 100));
            if (isFirst)
            {
                MessageBox.Show($"Вы должны получить число {udvoitel.Finish} за минимальное колличество шагов, путем прибавления 1 или умножения на 2.\n" +
                $"Удачи! :)", "Великий Удвоитель", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isFirst = false;
                gbGame.Enabled = true;
                UpdateInfo();
            }
            else
            {
                gbGame.Enabled = true;
                UpdateInfo();
            }
        }

            private void btnPlus_Click(object sender, EventArgs e)
        {
            if (udvoitel != null)
            {
                udvoitel.Plus();
                udvoitel.CounterPlus();
                UpdateInfo();
            }
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            udvoitel?.Multi();
            udvoitel.CounterPlus();
            UpdateInfo();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            udvoitel?.Reset();
            UpdateInfo();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblCurrent.Text = udvoitel?.History.ToString();
            udvoitel.CounterPlus();
            UpdateInfo();
        }
    }
}
