using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class SeedInput : Form
    {
        public SeedInput()
        {
            InitializeComponent();
        }

        public int GetSeed()
        {
            return (int)Scale.Value;
        }

        // Randomize button
        private void button1_Click(object sender, EventArgs e)
        {
            Random randSeed = new Random();
            int rseed = randSeed.Next();

            Scale.Value = rseed;
        }
    }
}
