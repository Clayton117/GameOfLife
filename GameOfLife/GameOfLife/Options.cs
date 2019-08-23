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
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        // Milliseconds Get
        public int GetInterval()
        {
            return (int)MilliUpDown.Value;
        }

        // Milliseconds Set
        public void SetInterval(int milliseconds)
        {
            MilliUpDown.Value = milliseconds;
        }

        // Width Get
        public int GetWidth()
        {
            return (int)WidthUpDown.Value;
        }

        // Width Set
        public void SetWidth(int width)
        {
            WidthUpDown.Value = width;
        }

        // Height Get
        public int GetHeight()
        {
            return (int)HeightUpDown.Value;
        }

        // Height Set
        public void SetHeight(int height)
        {
            HeightUpDown.Value = height;
        }
    }
}
