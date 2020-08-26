using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    // This class is the individual Cell objects which can either be alive or dead.
    class Cell
    {
        public bool IsAlive { get; set; }

        // Called to print to console whether they are alive or dead
        public void PrintAlive()
        {
            if(this.IsAlive == true)
            {
                Console.Write("O");
            } else
            {
                Console.Write(" ");
            }
        }

        // Returns a 1 if they are alive. 
        public int PlusOneIfAlive()
        {
            if (this.IsAlive == true)
            {
                return 1;
            } else
            {
                return 0;
            }
        }
    }
}
