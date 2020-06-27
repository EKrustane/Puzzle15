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
                    block = new PuzzleBlock();
                    block.Top = row*80;
                    block.Left = col*80;
                    block.Text = blockCount.ToString();
                    blockCount++;
                    this.Controls.Add(block);
                }
                
            }
        }
    }
}
