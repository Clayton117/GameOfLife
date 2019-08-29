using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        // Coordinates
        int nX = 30;
        int nY = 30;

        // For alive cells
        int isAlive = 0;

        // Bool for Finite(TRUE)/Toroidal(FALSE)
        bool boundaryType = true;

        // The universe/scartch-pad arrays
        bool[,] universe;
        bool[,] scratchPad;

        // Drawing colors
        Color GridColor;
        Color CellColor;
        Color BackgroundColor;

        // Get/Set for colors
        Color GridTemp;
        Color CellTemp;
        Color BGTemp;

        // The Timer class
        Timer timer = new Timer();

        // Milliseconds Interval
        int milliInterval = 20;

        // Generation count
        int generations = 0;

        // Randomize the seed
        int seed = 0;

        // If true, they're checked and shown
        bool gridShow = true;
        bool hudShow = true;
        bool neighborDraw = true;

        public Form1()
        {
            InitializeComponent();
            startSetting();

            // Setup the timer
            timer.Interval = milliInterval; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running

            // Grid
            if (gridShow == true)
            {
                gridVisibleToolStripMenuItem.Checked = true;
            }
            else
            {
                gridVisibleToolStripMenuItem.Checked = false;
            }

            // HUD
            if (hudShow == true)
            {
                hUDToolStripMenuItem.Checked = true;
            }
            else
            {
                hUDToolStripMenuItem.Checked = false;
            }

            // Neighbor Count
            if (neighborDraw == true)
            {
                neighborCountToolStripMenuItem.Checked = true;
            }
            else
            {
                neighborCountToolStripMenuItem.Checked = false;
            }

            universe = new bool[nX, nY];
            scratchPad = new bool[nX, nY];
        }

        // Alive cell count
        private int aliveCell()
        {
            int isAlive = 0;

            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int z = 0; z < universe.GetLength(1); z++)
                {
                    if (universe [i,z] == true)
                    {
                        isAlive++;
                    }
                }
            }

            return isAlive;
        }


        // Neighbor count for cells
        private int neighborCount(int a, int b)
        {
            int neighborAmount = 0; // Neighbor count int

            if (boundaryType == true) // true = finite
            {
                for (int x = -1; x < 2; ++x) // iterating through x in grid
                {
                    for (int y = -1; y < 2; ++y) // iterating through y in the grid
                    {
                        if (a > 0 && b > 0 && a < nX - 1 && b < nY - 1) // checks all of the inner cells
                        {
                            switch (x) // cases take care of all possibilities that X can be in this specfic if check
                            {
                                case -1:
                                    switch (y) // cases take care of all possibilities for Y, just like X
                                    {
                                        case -1:
                                            if (universe[a + x, b + y] == true)
                                            {
                                                neighborAmount++;
                                            }
                                            break;
                                        case 0:
                                            if (universe[a + x, b + y] == true)
                                            {
                                                neighborAmount++;
                                            }
                                            break;
                                        case 1:
                                            if (universe[a + x, b + y] == true)
                                            {
                                                neighborAmount++;
                                            }
                                            break;
                                    }
                                    break;

                                case 0:
                                    switch (y)
                                    {
                                        case -1:
                                            if (universe[a + x, b + y] == true)
                                            {
                                                neighborAmount++;
                                            }
                                            break;
                                        case 0:
                                            break;
                                        case 1:
                                            if (universe[a + x, b + y] == true)
                                            {
                                                neighborAmount++;
                                            }
                                            break;
                                    }
                                    break;

                                case 1:
                                    switch (y)
                                    {
                                        case -1:
                                            if (universe[a + x, b + y] == true)
                                            {
                                                neighborAmount++;
                                            }
                                            break;
                                        case 0:
                                            if (universe[a + x, b + y] == true)
                                            {
                                                neighborAmount++;
                                            }
                                            break;
                                        case 1:
                                            if (universe[a + x, b + y] == true)
                                            {
                                                neighborAmount++;
                                            }
                                            break;
                                    }
                                    break;
                            }

                        }
                        else
                        {
                            if (a == 0 && b == 0)
                            {
                                switch (x)
                                {
                                    case 1:
                                        switch (y)
                                        {
                                            case 1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (a == 0 && (b > 0 && b < nY - 1))
                            {
                                switch (x)
                                {
                                    case 0:
                                        switch (y)
                                        {
                                            case -1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            case 1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    case 1:
                                        switch (y)
                                        {
                                            case -1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            case 0:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            case 1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    default:
                                        break;

                                }
                            }
                            if (a == 0 && b == nY - 1)
                            {
                                switch (x)
                                {
                                    case 1:
                                        switch (y)
                                        {
                                            case -1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    default:
                                        break;
                                }

                            }
                            if (b == nY - 1 && (a > 0 && a < nX - 1))
                            {
                                switch (x)
                                {
                                    case -1:
                                        switch (y)
                                        {
                                            case -1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            case 0:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    case 0:
                                        switch (y)
                                        {
                                            case -1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    case 1:
                                        switch (y)
                                        {
                                            case -1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            case 0:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (b == nY - 1 && a == nX - 1)
                            {
                                switch (x)
                                {
                                    case -1:
                                        switch (y)
                                        {
                                            case -1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (a == nX - 1 && (b > 0 && b < nY - 1))
                            {
                                switch (x)
                                {
                                    case -1:
                                        switch (y)
                                        {
                                            case -1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            case 0:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            case 1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    case 0:
                                        switch (y)
                                        {
                                            case -1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            case 1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (a == nX - 1 && b == 0)
                            {
                                switch (x)
                                {
                                    case -1:
                                        switch (y)
                                        {
                                            case 1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                    break;
                                default:
                                    break;
                                }
                            }
                            if (b == 0 && (a > 0 && a < nX - 1))
                            {
                                switch (x)
                                {
                                    case -1:
                                        switch (y)
                                        {
                                            case 0:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            case 1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    case 0:
                                        switch (y)
                                        {
                                            case 1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    case 1:
                                        switch (y)
                                        {
                                            case 0:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            case 1:
                                                if (universe[a + x, b + y] == true)
                                                {
                                                    neighborAmount++;
                                                }
                                                break;
                                            default:
                                                break;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            return neighborAmount;
        }

        // Rules for living in the next generation
        private void cellRules()
        {
            int currentAlive = 0;

            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    currentAlive = neighborCount(x, y);

                    if ((currentAlive < 2 || currentAlive > 3) && universe[x, y] == true)
                    {
                        scratchPad[x, y] = false;
                    }

                    if (currentAlive == 3 && universe[x, y] == false)
                    {
                        scratchPad[x, y] = true;
                    }

                    if ((currentAlive == 2 || currentAlive == 3) && universe[x, y] == true)
                    {
                        scratchPad[x, y] = true;
                    }
                }
            }
        }

        // Swapping universe and scratch-pad
        private void swapped()
        {
            bool[,] tempArray = universe;

            universe = scratchPad;

            scratchPad = tempArray;

        }

        // Clears scratch-pad
        private void clearPad()
        {
            for (int x = 0; x < scratchPad.GetLength(0); x++)
            {
                for (int y = 0; y < scratchPad.GetLength(1); y++)
                {
                    if (scratchPad[x, y] == true)
                    {
                        scratchPad[x, y] = false;
                    }
                }
            }
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            generations++;
            cellRules();
            swapped();
            clearPad();

            graphicsPanel1.Invalidate();
        }

        // Handles window form graphics
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(GridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(CellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    RectangleF cellRect = RectangleF.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    if (gridShow == true)
                    {
                        // Outline the cell with a pen
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                    }

                    // Cell neighbor font
                    Font cellFont = new Font("Snap ITC", 10f);

                    StringFormat stringformat = new StringFormat();
                    stringformat.Alignment = StringAlignment.Center; // Alignment = horizontal align
                    stringformat.LineAlignment = StringAlignment.Center; // LineAlignment = vertical align

                    int neighborFont = neighborCount(x, y);
                    if (neighborFont > 0 && neighborDraw == true)
                    {
                        e.Graphics.DrawString(neighborFont.ToString(), cellFont, Brushes.Black, cellRect, stringformat);
                    }
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();

            int liveCount = aliveCell();

            Font HUDfont = new Font("Snap ITC", 10);
            StringFormat HUDform = new StringFormat();
            HUDform.LineAlignment = StringAlignment.Center;

            if (hudShow == true)
            {
                string HUDtext = "Generations = " + generations;
                e.Graphics.DrawString(HUDtext, HUDfont, Brushes.Red, 10, graphicsPanel1.ClientSize.Height -90, HUDform);

                HUDtext = "Cell Count = " + liveCount;
                e.Graphics.DrawString(HUDtext, HUDfont, Brushes.Red, 10, graphicsPanel1.ClientSize.Height -70, HUDform);

                HUDtext = "Boundary Type = " + boundaryType;
                e.Graphics.DrawString(HUDtext, HUDfont, Brushes.Red, 10, graphicsPanel1.ClientSize.Height -50, HUDform);

                HUDtext = "Universe Size = {Width: " + nX + ", Height: " + nY + "}";
                e.Graphics.DrawString(HUDtext, HUDfont, Brushes.Red, 10, graphicsPanel1.ClientSize.Height -30, HUDform);
            }

            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            Milliseconds.Text = "Milliseconds = " + milliInterval;
            Cells.Text = "Cells = " + liveCount;
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                isAlive++;

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        // Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /*
        // Accidental copy for New in File Menu
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (universe[x, y] == true)
                    {
                        universe[x, y] = false;
                    }
                }
            }

            isAlive = 0;
            generations = 0;
            timer.Enabled = false;

            graphicsPanel1.Invalidate();
        }
        */

        // Next button
        private void toolStripButtonNext_Click(object sender, EventArgs e)
        {
            generations++;
            cellRules();
            swapped();
            clearPad();

            graphicsPanel1.Invalidate();
        }

        // Pause button
        private void toolStripButtonPause_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        // Play button 
        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        // New button on strip (Empties universe)
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (universe[x, y] == true)
                    {
                        universe[x, y] = false;
                    }
                }
            }

            isAlive = 0;
            generations = 0;
            timer.Enabled = false;

            graphicsPanel1.Invalidate();
        }

        // New in File Menu (Empties universe)
        private void newToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (universe[x, y] == true)
                    {
                        universe[x, y] = false;
                    }
                }
            }

            isAlive = 0;
            generations = 0;
            timer.Enabled = false;

            graphicsPanel1.Invalidate();
        }

        // Randomize From Time
        private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random randTime = new Random();
            int time;

            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    time = randTime.Next() % 4;
                    if (time == 0)
                    {
                        universe[x, y] = true;
                    }
                    else
                    {
                        universe[x, y] = false;
                    }
                }
            }
            graphicsPanel1.Invalidate();
        }

        // Randomize Current Seed
        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random randCurrent = new Random(seed);
            int currentSeed;

            for (int x = 0; x < universe.GetLength(0); x++)
            {
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    currentSeed = randCurrent.Next() % 4;
                    if (currentSeed == 0)
                    {
                        universe[x, y] = true;
                    }
                    else
                    {
                        universe[x, y] = false;
                    }
                }
            }
            graphicsPanel1.Invalidate();
        }

        // Randomize Seed
        private void fromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeedInput input = new SeedInput();

            if (DialogResult.OK == input.ShowDialog())
            {
                seed = input.GetSeed();
            }
            fromCurrentSeedToolStripMenuItem_Click(sender, e);
        }

        // Save As in File Menu
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveAs = new SaveFileDialog();
            saveAs.Filter = "All Files|*.*|Cells|*.Cells";
            saveAs.FilterIndex = 2;
            saveAs.DefaultExt = "Cells";

            if (DialogResult.OK == saveAs.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(saveAs.FileName);
                writer.WriteLine("!This is a test");

                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    string thisRow = string.Empty;

                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        if (universe[x, y] == true)
                        {
                            thisRow += "&";
                        }
                        else if (universe[x, y] == false)
                        {
                            thisRow += ".";
                        }
                    }

                    writer.WriteLine(thisRow);
                }

                writer.Close();
            }
        }

        // Open in File Menu
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files|*.*|Cells|*.Cells";
            open.FilterIndex = 2;
            
            if (DialogResult.OK == open.ShowDialog())
            {
                StreamReader reader = new StreamReader(open.FileName);

                int maxWidth = 0;
                int maxHeight = 0;

                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();

                    if (row[0] == '!')
                    {
                        continue;
                    }

                    else if (row[0] != '!')
                    {
                        maxHeight++;
                    }

                    if (maxHeight != maxWidth)
                    {
                        maxWidth = maxHeight;
                    }
                }

                universe = new bool[maxWidth, maxHeight];
                scratchPad = new bool[maxWidth, maxHeight];

                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                int yPos = 0;

                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();

                    if (row[0] == '!')
                    {
                        continue;
                    }
                    else
                    {
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            if (row[xPos] == '&')
                            {
                                universe[xPos, yPos] = true;
                            }
                            else if (row[xPos] == '.')
                            {
                                universe[xPos, yPos] = false;
                            }
                        }
                    }

                    yPos++;
                }

                reader.Close();
            }

            graphicsPanel1.Invalidate();
        }

        // Options dialog window
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.SetInterval(milliInterval);

            options.SetWidth(nX);
            options.SetHeight(nY);

            if (DialogResult.OK == options.ShowDialog())
            {
                milliInterval = options.GetInterval();
                timer.Interval = milliInterval;

                nX = options.GetWidth();
                nY = options.GetHeight();

                universe = new bool[nX, nY];
                scratchPad = new bool[nX, nY];
            }
            graphicsPanel1.Invalidate();
        }

        // Grid Checked on/off
        private void gridVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridVisibleToolStripMenuItem.Checked == false)
            {
                gridVisibleToolStripMenuItem.Checked = true;
                gridShow = true;
            }

            else if (gridVisibleToolStripMenuItem.Checked == true)
            {
                gridVisibleToolStripMenuItem.Checked = false;
                gridShow = false;
            }

            graphicsPanel1.Invalidate();
        }

        // HUD Checked on/off
        private void hUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hUDToolStripMenuItem.Checked == false)
            {
                hUDToolStripMenuItem.Checked = true;
                hudShow = true;
            }

            else if (hUDToolStripMenuItem.Checked == true)
            {
                hUDToolStripMenuItem.Checked = false;
                hudShow = false;
            }

            graphicsPanel1.Invalidate();
        }

        // Neighbor Count Checked on/off
        private void neighborCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (neighborCountToolStripMenuItem.Checked == false)
            {
                neighborCountToolStripMenuItem.Checked = true;
                neighborDraw = true;
            }

            else if (neighborCountToolStripMenuItem.Checked == true)
            {
                neighborCountToolStripMenuItem.Checked = false;
                neighborDraw = false;
            }
        }

        // Reset
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            startSetting();

            graphicsPanel1.Invalidate();
        }

        // Reload 
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            startSetting();

            graphicsPanel1.Invalidate();
        }

        // Start and finish setting functions are for Reset and Reload
        private void startSetting()
        {
            BackgroundColor = Properties.Settings.Default.BGDefault;
            GridColor = Properties.Settings.Default.GridDefault;
            CellColor = Properties.Settings.Default.CellDefault;

            milliInterval = Properties.Settings.Default.MilliDefault;
            nX = Properties.Settings.Default.WidthDefault;
            nY = Properties.Settings.Default.HeightDefault;

            gridShow = Properties.Settings.Default.GridDrawDefault;
            hudShow = Properties.Settings.Default.HUDDrawDefault;
            neighborDraw = Properties.Settings.Default.NCDefault;
            boundaryType = Properties.Settings.Default.BoundarytypeDefault;
        }

        private void finishSetting()
        {
            Properties.Settings.Default.BGDefault = BackgroundColor;
            Properties.Settings.Default.GridDefault = GridColor;
            Properties.Settings.Default.CellDefault = CellColor;

            Properties.Settings.Default.MilliDefault = milliInterval;
            Properties.Settings.Default.WidthDefault = nX;
            Properties.Settings.Default.HeightDefault = nY;

            Properties.Settings.Default.GridDrawDefault = gridShow;
            Properties.Settings.Default.HUDDrawDefault = hudShow;
            Properties.Settings.Default.NCDefault = neighborDraw;
            Properties.Settings.Default.BoundarytypeDefault = boundaryType;
        }

        private void Forms1_formClosed(object sender, FormClosedEventArgs e)
        {
            finishSetting();
            Properties.Settings.Default.Save();
        }

        // Background Color
        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog background = new ColorDialog();

            background.Color = BackgroundColor;
            if (DialogResult.OK == background.ShowDialog())
            {
                BackgroundColor = background.Color;
                SetBGColor(BackgroundColor);
                graphicsPanel1.BackColor = GetBGColor();
            }

            graphicsPanel1.Invalidate();
        }

        private Color GetBGColor()
        {
            return BGTemp;
        }
        private void SetBGColor(Color color)
        {
            BGTemp = color;
            BackgroundColor = color;
        }

        // Cell Color
        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cell = new ColorDialog();

            cell.Color = CellColor;
            if (DialogResult.OK == cell.ShowDialog())
            {
                CellColor = cell.Color;
                SetCellColor(CellColor);
            }

            graphicsPanel1.Invalidate();
        }

        private Color GetCellColor()
        {
            return CellTemp;
        }
        private void SetCellColor(Color color)
        {
            CellTemp = color;
            CellColor = color;
        }


        // Grid Color
        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog grid = new ColorDialog();

            if (DialogResult.OK == grid.ShowDialog())
            {
                GridColor = grid.Color;
                SetGridColor(GridColor);
            }

            graphicsPanel1.Invalidate();
        }

        private Color GetGridColor()
        {
            return GridTemp;
        }
        private void SetGridColor(Color color)
        {
            GridTemp = color;
            GridColor = GridTemp;
        }

    }
}
