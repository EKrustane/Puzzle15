using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleFifteen
{
    public partial class PuzzleArea : Form
    {
        Random rand = new Random();
        List<Point> initialLocations = new List<Point>();
        public PuzzleArea()
        {
            InitializeComponent();
            InitializePuzzleArea();
            InitializeBlocks();
            ShuffleBlocks();
        }

        private void InitializePuzzleArea()
        {
            this.BackColor = Color.CornflowerBlue;
            this.Text = "Puzzle15";
            this.Height = 520;
            this.Width = 500;
        }
        private void InitializeBlocks()
        {
            int blockCount = 1;
            PuzzleBlock block;
            for(int row = 1; row < 5; row++)
            {
                for (int col = 1; col < 5; col++)
                {
                    block = new PuzzleBlock()
                    {  
                    Top = row * 80,
                    Left = col * 80,
                    Text = blockCount.ToString(),
                    Name = "Block" + blockCount.ToString()
                    };
                    block.Click += new EventHandler(Block_Click);
                    //(same)  block.Click += Block_Click;
                    initialLocations.Add(block.Location);
                    if(blockCount==16)
                    {
                        block.Name = "EmptyBlock";
                        block.Text = string.Empty;
                        block.BackColor = Color.CornflowerBlue;
                        block.FlatStyle = FlatStyle.Flat;
                        block.FlatAppearance.BorderSize = 0;
                    }
                    blockCount++;
                    this.Controls.Add(block);
                }
                
            }
        }

        private void Block_Click(object sender, EventArgs e)
        {
            Button block = (Button)sender;
            if (IsAdjacent(block))
            {
                SwapBlocks(block);
                CheckForWin();
            }
            
        }

        private void SwapBlocks(Button block)
        {
            Button emptyBlock = (Button)this.Controls["EmptyBlock"];
            Point oldLocation = block.Location;
            /* (same like Point.....)
             int oldLeft = block.Left;
             int oldTop = block.Top;
             emptyblock.Left = oldlLeft;
             emptyblock.Top = oldTop;
            */
            block.Location = emptyBlock.Location;
            emptyBlock.Location = oldLocation;
        }

        private bool IsAdjacent(Button block)
        {
            double a;
            double b;
            double c;
            Button emptyBlock = (Button)this.Controls["EmptyBlock"];
            a = emptyBlock.Top - block.Top; //modulis a = Math.Abs(emptyBlock.Top - block.Top);
            b = emptyBlock.Left - block.Left;
            c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            if (c< 81)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void ShuffleBlocks()
        {
            int randNumber;
            string blockName;
            Button block;
            for(int i=0; i<100; i++)
            {
                randNumber = rand.Next(1, 16);
                blockName = "Block" + randNumber.ToString();
                block = (Button)this.Controls[blockName];
                SwapBlocks(block);
            }
        }

        private void puzzleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShuffleBlocks();
        }

        private void CheckForWin()
        {
            string blockName;
            Button block;

            for (int i = 1; i < 16; i++)
            {
                blockName = "Block" + i.ToString();
                block = (Button)this.Controls[blockName];
                if (block.Location != initialLocations[i - 1])
                {
                    return;
                }
                
            }
            PuzzleSolved();
        }

        private void PuzzleSolved()
        {
            MessageBox.Show("You solved that!");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    
}
