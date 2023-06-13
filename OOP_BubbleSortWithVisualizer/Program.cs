using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_BubbleSortWithVisualizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] visualizerSize = { 29, 120 }; // rows and columns of console

            Random rnd = new Random();
            int[] arr = new int[visualizerSize[1]];
            int[] newDispl = new int[visualizerSize[1]];
            int[] curDispl = new int[visualizerSize[1]];
            int temp = 0;

            for (int x = 0; x < arr.Length; x++)
            {
                arr[x] = rnd.Next(visualizerSize[0]) + 1;
                newDispl[x] = 0;
                curDispl[x] = 1;
            }

            // this line just sets the window size to always display in a 
            // 120 * 30 characters in size
            Console.SetWindowSize(visualizerSize[1], visualizerSize[0] + 1);

            curDispl = visualizeDisplay(arr, visualizerSize[0], newDispl, curDispl, "Initial Display", 2, 0);

            for (int x = 0; x < arr.Length; x++)
            {
                for (int y = 0; y < arr.Length - 1; y++)
                {
                    newDispl[y] = 1;
                    newDispl[y + 1] = 2;

                    curDispl = visualizeDisplay(arr, visualizerSize[0], newDispl, curDispl, "Thinking", 0, 0);

                    if (arr[y] > arr[y + 1])
                    {
                        temp = arr[y];
                        arr[y] = arr[y + 1];
                        arr[y + 1] = temp;

                        newDispl[y] = 3;
                        newDispl[y + 1] = 3;
                    }

                    curDispl = visualizeDisplay(arr, visualizerSize[0], newDispl, curDispl, "Swapping", 0, 0);

                    curDispl = visualizeDisplay(arr, visualizerSize[0], newDispl, curDispl, "", 0, 0);

                }
            }

            Console.SetCursorPosition(0, 29);
            Console.Write("Done!!!!!!!!!                                              ");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays the visual representation of the sorting algorithm
        /// </summary>
        /// <param name="arr"> Array that contains the numbers to be sorted </param>
        /// <param name="dispMax"> The max number to be generated, as of this point it should always be linked to visualizerSize[0] </param>
        /// <param name="newDispl"> The array of numbers representing the colors of the change </param>
        /// <param name="curDispl"> The array of numbers representing what is currently displayed </param>
        /// <param name="message"> The message to be printed out after the display update of the visualizer </param>
        /// <param name="wait"> 0 for no wait, 1 for thread sleep and 2 for ReadKey </param>
        /// <param name="dur"> Duration of the sleep, will only be considered if wait is 1. This is measured in ms </param>
        /// <returns> The updated current display </returns>
        static int[] visualizeDisplay(int[] arr, int dispMax, int[] newDispl, int[] curDispl, string message, int wait, int dur)
        {
            for (int a = 0; a < arr.Length; a++)
            {
                for (int b = dispMax; b > 0; b--)
                {
                    if (newDispl[a] != curDispl[a])
                    {
                        Console.SetCursorPosition(a, b - 1);
                        switch (newDispl[a])
                        {
                            case 0:
                                Console.ResetColor();
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                        }

                        if (arr[a] > dispMax - b)
                            Console.Write("*");
                        else
                            Console.Write(" ");
                    }
                }

                curDispl[a] = newDispl[a];
                newDispl[a] = 0;
            }
            Console.SetCursorPosition(0, 29);
            Console.Write(afterDisplayStringBuilder(message));

            if (wait == 1)
                Thread.Sleep(dur);
            else if (wait == 2)
                Console.ReadKey();

            return curDispl;
        }

        static string afterDisplayStringBuilder(string message)
        {
            while(message.Length < 100)
                message += " ";

            return message;
        }
    }
}
