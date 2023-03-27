using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Microsoft.VisualBasic;


namespace Maze
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            

        }

        private async void problem1_button_Click(object sender, EventArgs e)
        {
            

            Problem1 problem1 = new Problem1();
            problem1.Show();
            
            
            
        }

        private void problem2_button_Click(object sender, EventArgs e)
        {
            Problem2 problem2 = new Problem2();
            problem2.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
