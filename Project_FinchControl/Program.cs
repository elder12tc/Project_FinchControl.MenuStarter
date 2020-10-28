using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Elder, Joseph
    // Dated Created: 1/22/2020
    // Last Modified: 10/21/2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot); 
                        break;

                    case "d":

                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

       

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Do a Dance");
                Console.WriteLine("\tc) Play a Song");
                Console.WriteLine("\td) Light Sound and Move");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        DisplayDoADance(finchRobot);
                        break;

                    case "c":
                        DisplayPlayASong(finchRobot);
                        break;

                    case "d":
                        DisplayLightSoundAndMove(finchRobot);

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel += 10)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
                finchRobot.wait(1000);
                finchRobot.noteOff();
                finchRobot.setLED(0, 0, 0);
            }

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Do A Dance                        *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayDoADance(Finch finchRobot)
        {
           

            string userChoice;
            bool quitToTalentShowMenu; 

            Console.CursorVisible = false;

            DisplayScreenHeader("Do A Dance");

            
            Console.WriteLine("\tIt is your choice.");
            Console.WriteLine("\tc) Circle");
            Console.WriteLine("\ts) Square");
            Console.WriteLine("\tq) Return to menu.");
            Console.Write("\t\tEnter Choice:");
            userChoice = Console.ReadLine();
            


            switch (userChoice)
            {
                case "c":
                    Console.WriteLine("Finch will do a circle");
                    DisplayContinuePrompt();
                    for (int i = 0; i < 4; i++)
                    {
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(1000);
                    }
                    break;

                case "s":
                    Console.WriteLine("Finch will do a square");
                    DisplayContinuePrompt();
                    for (int i = 0; i < 1; i++)
                    {
                        finchRobot.setMotors(255, 255);
                        finchRobot.wait(500);
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(550);
                        finchRobot.setMotors(255, 255);
                        finchRobot.wait(500);
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(550);
                        finchRobot.setMotors(255, 255);
                        finchRobot.wait(500);
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(550);
                        finchRobot.setMotors(255, 255);
                        finchRobot.wait(500);
                        finchRobot.setMotors(255, 50);
                        finchRobot.wait(550);
                    }
                    break;

                case "q":
                    quitToTalentShowMenu = true;

                    break;

                default:
                    Console.WriteLine("Enter (c) or (s) or (q)");
                    break;
            }

            finchRobot.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Play A Song                       *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DisplayPlayASong(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Play A Song");

            Console.WriteLine("\tThe Finch robot will now play a song!");
            DisplayContinuePrompt();

            // song = Beethoven - Fur Elise
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(311);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(311);
            finchRobot.wait(500);
            finchRobot.noteOn(261);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(261);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(261);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(311);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(311);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(311);
            finchRobot.wait(500);
            finchRobot.noteOn(261);
            finchRobot.wait(500);
            finchRobot.noteOff();

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light, Sound, And Move            *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        private static void DisplayLightSoundAndMove(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("DisplayLightSoundAndMove");

            Console.WriteLine("\tThe Finch robot will now show off it's lights while doing a song and dance.");
            DisplayContinuePrompt();

            
            for (int i = 0; i < 1; i++)
            {

                DisplayMusic(finchRobot);
                finchRobot.setLED(i, 255, i);
                finchRobot.setMotors(255, 255);
                finchRobot.wait(2000);
                finchRobot.setMotors(-255, -255);
                finchRobot.wait(200);
                finchRobot.setMotors(255, 128);
                finchRobot.wait(200);
                finchRobot.setMotors(128, 255);
                finchRobot.wait(200);
            }
            finchRobot.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }

        static void DisplayMusic(Finch finchRobot)
        {
            // song = rick astley - 'Never Going To Give You Up'

            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(369);
            finchRobot.wait(500);
            finchRobot.noteOn(369);
            finchRobot.wait(500);
            finchRobot.noteOn(349);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(500);
            finchRobot.noteOn(446);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.wait(500);
            finchRobot.setLED(0, 0, 255);
            finchRobot.noteOn(277);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.wait(500);
            finchRobot.setLED(255, 255, 255);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(277);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.setLED(255, 0, 0);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(369);
            finchRobot.wait(500);
            finchRobot.noteOn(369);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.setLED(0, 255, 0);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(277);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.wait(500);
            finchRobot.noteOn(277);
            finchRobot.wait(500);
            finchRobot.setLED(0, 0, 255);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.wait(500);
            finchRobot.noteOn(493);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.setLED(255, 255, 255);
            finchRobot.noteOn(277);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(440);
            finchRobot.wait(500);
            finchRobot.noteOn(329);
            finchRobot.wait(500);
            finchRobot.noteOn(293);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);


            DisplayMenuPrompt("Talent Show Menu");
        }

        #endregion


        #region data recorder

        /// <summary>
        /// *****************************************************************
        /// *                     Data Recorder Menu                        *
        /// *****************************************************************
        /// </summary>

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            string menuChoice;

            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            bool quitDataRecorderMenu = false;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // user menu
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Return to Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // switch case for user menu
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for what you would like to do.");
                        DisplayContinuePrompt();
                        break;
                } 

            } while (!quitDataRecorderMenu);

        }

        /// <summary>
        /// *****************************************************************
        /// *               Data Recorder > Get Number of Data Points       *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            bool validResponse;
            string userResponse;

            do
            {
                DisplayScreenHeader("Get Number of Data Points");
                Console.WriteLine("Number of Data Points: ");
                userResponse = Console.ReadLine();

                
                validResponse = int.TryParse(userResponse, out numberOfDataPoints);

                if (!validResponse)
                {
                    Console.WriteLine("Please Enter the Number of Data Points You Would Like to Collect: ");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine($"Number of Data Points: {numberOfDataPoints}");

            } while (!validResponse);

            DisplayContinuePrompt();

            return numberOfDataPoints;

        }

        /// <summary>
        /// *****************************************************************
        /// *               Data Recorder > Get Data Point Frequency        *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static double DataRecorderDisplayGetDataPointFrequency()
        {
            int dataPointFrequency;
            bool validResponse;
            string userResponse;

            do
            {
                DisplayScreenHeader("Get Data Point Frequency");

                Console.WriteLine("Data Point Frequency: ");

                userResponse = Console.ReadLine();

                
                validResponse = int.TryParse(userResponse, out dataPointFrequency);

                if (!validResponse)
                {
                    Console.WriteLine("Please Enter the Data Point Frequency (Time is in Seconds): ");
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine($"Data Point Frequency: {dataPointFrequency}");
            } while (!validResponse);


            DisplayContinuePrompt();

            return dataPointFrequency;

        }

        /// <summary>
        /// *****************************************************************
        /// *               Data Recorder > Display Get Data                *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];
            int frequencyInSeconds;

            DisplayScreenHeader("Get The Data");

            // echo number of data points to user

            Console.WriteLine("The Finch Robot Will Now Record Temperatures");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = finchRobot.getTemperature();
                Console.WriteLine($"Data Point #{index + 1}: {temperatures[index] * 9 / 5 + 32} farenheit");
                frequencyInSeconds = (int)(dataPointFrequency * 500);
                finchRobot.wait(frequencyInSeconds);
            }

            Console.WriteLine();
            Console.WriteLine("Current Data");
            DataRecorderDisplayDataTable(temperatures);
            Console.WriteLine();
            Console.WriteLine($"Average Tempurature: {temperatures.Average()}");

            DisplayContinuePrompt();

            return temperatures;
        }

        /// <summary>
        /// *****************************************************************
        /// *               Data Recorder > Display Data                    *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>

        static void DataRecorderDisplayDataTable(double[] temperatures)
        {
            //
            // display for data table
            //
            Console.WriteLine("Data Point".PadLeft(10) + "Temperatures".PadLeft(10));
                
            Console.WriteLine("**********".PadLeft(10) + "************".PadLeft(10));
                
            //
            // the table data
            //
            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine((index + 1).ToString().PadLeft(10) + (temperatures[index] * 9 / 5 + 32).ToString("n2").PadLeft(10));
                
            }
        }

        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayScreenHeader("Display Data");

            DataRecorderDisplayDataTable(temperatures);

            DisplayContinuePrompt();
        }

       

        

       

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch Robot is now Disconnected.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to the Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(128, 128, 0);
            finchRobot.wait(1000);
            finchRobot.setLED(128, 0, 255);
            finchRobot.wait(1000);
            finchRobot.setLED(128, 128, 255);
            finchRobot.wait(1000);
            finchRobot.setLED(0, 128, 64);
            finchRobot.wait(2000);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOn(277);
            finchRobot.wait(1000);
            finchRobot.noteOn(311);
            finchRobot.wait(1000);
            finchRobot.noteOn(369);
            finchRobot.wait(1000);
            finchRobot.noteOn(415);
            finchRobot.wait(1000);
            finchRobot.noteOff();


            return robotConnected;


        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
