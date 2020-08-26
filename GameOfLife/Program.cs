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
            StartUp();
            Console.Read();
        }

        public static void StartUp()
        {
            Cell[,] MapOne = Map.CreateMap();
            Cell[,] MapTwo = GetLiveCells(MapOne);
            InfinityLife(MapTwo);
        }

        public static void InfinityLife(Cell[,] Life)
        {
            Cell[,] cells = Life;            
            bool NextCycle = true;

            while (NextCycle)
            {                
                Cell[,] cells2 = Map.UpdateMap(cells);
                string input = Console.ReadLine();
                if(input.ToLower() == "e")
                {
                    NextCycle = false;
                }
                cells = cells2;
            }
        }

        public static Cell[,] GetLiveCells(Cell[,] Map)
        {
            bool KeepGoing = true;
            Cell[,] MapOne = Map;
            while (KeepGoing)
            {
                Console.WriteLine("Select living cells (11-22)");
                string input = Console.ReadLine();

                try
                {
                    string[] nums = input.Split('-');
                    int pos1 = Int32.Parse(nums[0]); 
                    int pos2 = Int32.Parse(nums[1]);
                    MapOne[pos1, pos2].IsAlive = true;
                    Console.WriteLine("Add Another?");
                    string input2 = Console.ReadLine();
                    if (input2.ToUpper() != "Y")
                    {
                        KeepGoing = false;
                    }
                }
                catch (Exception)
                {
                    GetLiveCells(MapOne);
                }
            }

            return MapOne;
        }
    }
}
