using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace montyhall
{
    class Program
    {

        static void Main(string[] args)
        {


            int numWinsScenarioA = 0;
            int numWinsScenarioB = 0;
            int tries = 1000000;
            int winningWindow = 1;

            Console.WriteLine("Lets Try Scenario A - Player sticks with original pick");
            for (int i = 0; i < tries; i++)
            {
                //Console.WriteLine("Attempt " + i);
                int playersWindow = pickRandomWindow();

                if (playersWindow == winningWindow)
                {
                    numWinsScenarioA += 1;
                    //Console.WriteLine("Win!");
                }
            }
            Console.WriteLine("There were " + numWinsScenarioA + " wins out of " + tries + " attempts.");


            Console.WriteLine("");
            Console.WriteLine("Lets Try Scenario B - Player changes initial pick");
            for (int i = 0; i < tries; i++)
            {
                //Console.WriteLine("Attempt " + i);
                
                int playersWindow = pickRandomWindow();
                int shownWindow = pickShowWindow(playersWindow);


                if (playersWindow == 1 && shownWindow == 2)
                {
                    playersWindow = 3;
                }
                else if (playersWindow == 1 && shownWindow == 3)
                {
                    playersWindow = 2;
                }
                else if (playersWindow == 2 && shownWindow == 3)
                {
                    playersWindow = 1;
                }
                else if (playersWindow == 3 && shownWindow == 2)
                {
                    playersWindow = 1;
                }


                if (playersWindow == winningWindow)
                {
                    numWinsScenarioB += 1;
                    //Console.WriteLine("Win!");
                }
            }
            Console.WriteLine("There were " + numWinsScenarioB + " wins out of " + tries + " attempts.");



            Console.Read();
        }


        protected static int pickRandomWindow()
        {
            CryptoRandom rng = new CryptoRandom();
            int userChoice = 0;
            userChoice = rng.Next(1, 4);
            return userChoice;
        }

        protected static int pickShowWindow(int playersWindow)
        {
            CryptoRandom rng = new CryptoRandom();
            int showWindow = 0;
            showWindow = rng.Next(2, 4);

            while (showWindow == playersWindow)
            {
                showWindow = rng.Next(2, 4);
            }

            return showWindow;
        }



    }
}
