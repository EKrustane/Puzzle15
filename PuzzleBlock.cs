using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleFifteen
{
    class PuzzleBlock : Button
    {
        public PuzzleBlock()
        {
            InitializePuzzleBlock();
        }
        private void InitializePuzzleBlock()
        {
            this.BackColor = Color.LightCoral;
            this.Height = 80;
            this.Width = 80;
            this.Text = "0";
            this.Font = new Font("Consolas", 18);
        }


    }
}
