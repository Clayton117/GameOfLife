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
    /* THINGS TO FINISH FOR MILESTONE!!!
       
        1) Finish neighborCount function --- COMPLETED!!
        2) Set up buttons: --- COMPLETED!!
           New <---- Empties the universe, oviously
           Start
           Pause
           Next
        3) Make sure that all rules apply when application starts    --- COMPLETED!!!
           A -- Living cells with less than 2 living neighbors die in the next generation
           B -- Living cells with more than 3 living neighbors die in the next generation
           C -- Living cells with 2 or 3 living neighbors live in the next generation
           D -- Dead cells with exactly 3 living neighbors live in the next generation
        4) Fix grid --- COMPLETED!!!
     */  

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
        Color gridColor = Color.Black;
        Color cellColor = Color.Yellow;

        //Drawing labels
        bool neighborDraw = true;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        public Form1()
        {
            InitializeComponent();

            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running

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

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);

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

            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
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

        // New button (Makes universe empty)
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
    }
}
