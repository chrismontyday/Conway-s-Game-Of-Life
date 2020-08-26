using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Map
    {
        // Creates a two deminsional boolean array of Cell Objects
        public static Cell[,] CreateMap(int MapWidth = 100, int MapHeight = 20)
        {
            try
            {
                Cell[,] Map = new Cell[MapHeight, MapWidth];

                for (int i = 0; i < MapHeight; i++)
                {
                    for (int j = 0; j < MapWidth; j++)
                    {
                        Cell cell = new Cell();
                        cell.IsAlive = false;
                        Map[i, j] = cell;
                    }
                }
                return Map;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Prints the map to the console. 
        public static void PrintMap(Cell[,] Map)
        {

            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Map[i, j].PrintAlive();
                }
                Console.WriteLine();
            }
        }

        // Give this a map and it will return a correctly updated map. 
        public static Cell[,] UpdateMap(Cell[,] Map)
        {
            Cell[,] NewMap = Map;

            for(int i = 0; i < Map.GetLength(0); i++)
            {
                for(int j = 0; j < Map.GetLength(1); j++)
                {
                    // Creates a border of asterisks in the else part of the statement. 
                    if (i != 0 || j != 0 || i != Map.GetLength(0) || j != Map.GetLength(1))
                    {

                        int neighbors = 0;
                        neighbors += Map[i - 1, j].PlusOneIfAlive();
                        neighbors += Map[i + 1, j].PlusOneIfAlive();
                        neighbors += Map[i, j - 1].PlusOneIfAlive();
                        neighbors += Map[i, j + 1].PlusOneIfAlive();
                        neighbors += Map[i - 1, j - 1].PlusOneIfAlive();
                        neighbors += Map[i + 1, j - 1].PlusOneIfAlive();
                        neighbors += Map[i - 1, j + 1].PlusOneIfAlive();
                        neighbors += Map[i + 1, j + 1].PlusOneIfAlive();

                        switch (neighbors)
                        {
                            case 1:
                                NewMap[i, j].IsAlive = false;
                                break;
                            case 2:
                                if (NewMap[i, j].IsAlive == true)
                                {
                                    NewMap[i, j].IsAlive = true;
                                } else
                                {
                                    NewMap[i, j].IsAlive = false;
                                }
                                break;
                            case 3:
                                NewMap[i, j].IsAlive = true;
                                break;
                            case 4:
                                NewMap[i, j].IsAlive = false;
                                break;
                            case 5:
                                NewMap[i, j].IsAlive = false;
                                break;
                            case 6:
                                NewMap[i, j].IsAlive = false;
                                break;
                            case 7:
                                NewMap[i, j].IsAlive = false;
                                break;
                            case 8:
                                NewMap[i, j].IsAlive = false;
                                break;
                        }
                        NewMap[i, j].PrintAlive();
                    }
                    else
                    {
                        Console.Write('*');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n\n\n");
            return NewMap;
        }
    }
}
