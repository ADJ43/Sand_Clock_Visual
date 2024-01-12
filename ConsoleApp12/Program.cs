using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp12
{
    internal class Program
    { 


class SandClock
        {
            static Timer timer;
            static int timePassed = 0;
            static int totalTime = 15; // Total time in seconds for the timer
            static int lapse = 0;
            static int lapseInput = 0;

            static void Main(string[] args)
            {
                Console.WriteLine("Enter timer in seconds. Only integers please :)");
                string input = Console.ReadLine();
                lapseInput = int.Parse(input);

                SetupTimer();
                Console.ReadKey(); // Wait for user input to exit

            }

            static void SetupTimer()
            {
                lapse = lapseInput;
                timer = new Timer(lapse * 1000 / 15); // Set up the timer for 1-second intervals
                timer.Elapsed += OnTimedEvent;
                timer.AutoReset = true;
                timer.Enabled = true;
            }

            static void OnTimedEvent(Object source, ElapsedEventArgs e)
            {
                timePassed++;
                UpdateDisplay();
                if (timePassed >= totalTime)
                {
                    timer.Stop();
                    Console.WriteLine("\nTimer finished.");
                }
            }

            static void UpdateDisplay()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray; // Set color to gray

                int halfTime = totalTime / 2;
                int size = 5; // Total height of each half of the sand clock
                int consoleWidth = Console.WindowWidth;
                int clockWidth = size; // Maximum width of the sand clock
                int leftPadding = (consoleWidth - clockWidth + 1) / 2; // Calculate left padding for centering

                // Calculate how many lines of sand should be in each half
                int sandTop = size - Math.Min(halfTime, timePassed);
                int sandBottom = Math.Max(0, timePassed - halfTime);

                // Top half of the sand clock
                for (int i = 0; i < size; i++)
                {
                    Console.Write(new String(' ', leftPadding)); // Add left padding for centering
                    if (i < sandTop)
                    {
                        Console.WriteLine(new String(' ', i) + new String('█', size - i) + new String('█', size - i));
                    }
                    else
                    {
                        Console.WriteLine(new String(' ', i));
                    }
                }

                // Bottom half of the sand clock
                for (int i = 0; i < size; i++)
                {
                    Console.Write(new String(' ', leftPadding)); // Add left padding for centering
                    if (i < sandBottom)
                    {
                        Console.WriteLine(new String(' ', size - i - 1) + new String('█', i + 1) + new String('█', i + 1));
                    }
                    else
                    {
                        Console.WriteLine(new String(' ', size - i - 1));
                    }
                }

                Console.ResetColor(); // Reset color to default
                Console.WriteLine("\nTime: " + timePassed + "s");
            }


        }

    }

}
