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
            //There are three windows/doors/curtains, whatever. 
            //Only one is the winner. But you can't tell until the window is opened.
            //You choose a window 1,2 or 3.
            //After choosing one of the remaining windows is opened to show that it is not the winner.
            //Now there are only 2 windows left, one is the one you initially picked.
            //You now have the option of staying with your selection, or choosing the other remaining window.
            //Do your chances change if you change your initial selection to the remaining window?
            //The paradox is that by changing your initial selection, you're chances of winning improve.
            //Let's test that...

            int numWinsScenarioA = 0;//Final result for Scenario A - Player sticks with original pick.
            int numWinsScenarioB = 0;//Final result for Scenario B - Player chooses the other window.
            int tries = 1000000; //Number of trials. 1 million should suffice.
            int winningWindow = 1;//We will make 1 be the winning window, it doesn't need to change for this test.

            Console.WriteLine("Lets Try Scenario A - Player sticks with original pick");
            for (int i = 0; i < tries; i++)
            {
                //Console.WriteLine("Attempt " + i);
                int playersWindow = pickRandomWindow();//Player makes his initial choice. Random number between 1 and 3.

                if (playersWindow == winningWindow)//Did she select the winning window?
                {
                    numWinsScenarioA += 1; //If so, Scenario A gets a win.
                    //Console.WriteLine("Win!");
                }
            }
            Console.WriteLine("There were " + numWinsScenarioA + " wins out of " + tries + " attempts.");


            Console.WriteLine("");
            Console.WriteLine("Lets Try Scenario B - Player changes initial pick");
            for (int i = 0; i < tries; i++)
            {
                //Console.WriteLine("Attempt " + i);
                
                int playersWindow = pickRandomWindow();//Player makes his initial choice. Random number between 1 and 3.
                int shownWindow = pickShowWindow(playersWindow);//The shown window is the window 2 or 3 that was not picked.

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


                if (playersWindow == winningWindow)//After switching, did she get the winning window?
                {
                    numWinsScenarioB += 1;//If so chalk up a win for Scenario B.
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
            switch (playersWindow)
            {
                case 2:
                    return 3;
                case 3:
                    return 2;
                default://should never hit
                    return 3;
            }
        }



    }
}
