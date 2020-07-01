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
        public PuzzleArea()
        {
            InitializeComponent();
            InitializePuzzleArea();
            InitializeBlocks();
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
    }
}
