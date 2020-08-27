using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {           
            Cell[,] MapOne = Map.CreateMap();
            Cell[,] MapTwo = GetLiveCells(MapOne);
            InfinityLife(MapTwo);
            Console.Read();
        }

        // Takes in living cells from User. Poor UI but it works. 
        public static Cell[,] GetLiveCells(Cell[,] Map)
        {
            bool KeepGoing = true;
            Cell[,] MapOne = Map;
            while (KeepGoing)
            {
                Console.WriteLine("Select living cells  (ex: '11-22')\n(x) To start game.");
                string input = Console.ReadLine();
                Console.CancelKeyPress += new ConsoleCancelEventHandler(UserClose);

                try
                {                                   
                    if (input.ToUpper() == "X")
                    {
                        KeepGoing = false;
                    }

                    int[] pos = ReadUserInput(input);
                    MapOne[pos[0]+1, pos[1]+1].IsAlive = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("I'm sorry but that didn't work. Try again.");
                }
            }

            return MapOne;
        }

        // Runs each generation and applies logic from the UpdateMap() method in Map.
        public static void InfinityLife(Cell[,] Life)
        {
            Cell[,] cells = Life;            
            bool NextCycle = true;

            while (NextCycle)
            {                
                Cell[,] cells2 = Map.UpdateMap(cells);
                string input = Console.ReadLine();
                Console.CancelKeyPress += new ConsoleCancelEventHandler(UserClose);

                if (input.ToLower() == "x")
                {
                    NextCycle = false;
                }
                cells = cells2;
            }
        }
        
        // Must be placed in a Try/Catch
        private static int[] ReadUserInput(string input)
        {
            int[] twoNumber = new int[2];
            
            string[] nums = input.Split('-');
            twoNumber[0] = Int32.Parse(nums[0]); 
            twoNumber[1] = Int32.Parse(nums[1]);

            return twoNumber;
        }

        // Called whenever input is taken by the User to prevent a CTRL+C Exit.  
        public static void UserClose(object sender, ConsoleCancelEventArgs args)
        {

            Console.WriteLine("\nThe read operation has been interrupted.");

            Console.WriteLine("  Key pressed: {0}", args.SpecialKey);

            Console.WriteLine("  Cancel property: {0}", args.Cancel);

            // Set the Cancel property to true to prevent the process from terminating.
            Console.WriteLine("Setting the Cancel property to true...");
            args.Cancel = true;

            // Announce the new value of the Cancel property.
            Console.WriteLine("  Cancel property: {0}", args.Cancel);
            Console.WriteLine("The read operation will resume...\n");
        }
    }
}
