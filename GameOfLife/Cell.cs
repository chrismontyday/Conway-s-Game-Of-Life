using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Cell
    {
        public bool IsAlive { get; set; }

        public void PrintAlive()
        {
            if(this.IsAlive == true)
            {
                Console.Write("1");
            } else
            {
                Console.Write("0");
            }
        }

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
