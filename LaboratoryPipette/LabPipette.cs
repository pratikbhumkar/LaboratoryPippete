using LaboratoryPipette.Entities;
using LaboratoryPipette.Modules;
using System;

namespace LaboratoryPipette
{
    /*
    * The execution for Laboratory pipette starts here.
    */
    public class LabPipette
    {
        //Flag indicating if the pipe is placed over a well.
        public bool placed = false;
        /*
        *This method formats the input for place command. Takes in the command string and arm object.
        */
        public void PlacePipe(string command, RoboticArm arm)
        {
            command = command.Replace("Place", "");
            var cordinates = command.Split(",");
            if (cordinates.Length == 2)//If the command string is valid
            {
                arm.Place(int.Parse(cordinates[0].Trim()), int.Parse(cordinates[1].Trim()));
                placed = true;
            }
            else    //Otherwise
            {
                Console.WriteLine("Invalid values");
            }
        }
        public void runPipette(){
            Plate plate = new Plate(5, 5); //Setting 5,5 as length and breadth for the plate.
            RoboticArm arm = new RoboticArm(plate);
            
            bool exitFlag = true; //Flag determining the exit menu.
            do
            {
                Console.WriteLine("Enter your command");
                Console.WriteLine("Type 'Exit' to Exit the program");
                String command = Console.ReadLine().Trim(); //Reading command
                try
                {
                    if (!this.placed) //Making sure that the program starts with Place command
                    {
                        if (command.StartsWith("Place"))
                        {
                            this.PlacePipe(command, arm);
                        }
                        else
                        {
                            Console.WriteLine("First command must be a place");
                        }
                    }
                    else if (this.placed) //Once placed.
                    {
                        if (command == "Exit") //If user wishes to exit.
                        {
                            exitFlag = false;
                        }
                        else
                        {
                            if (command.StartsWith("Place"))//Place command.
                            {
                                this.PlacePipe(command, arm);
                            }
                            else
                            {
                                //Switch control for commands.
                                switch (command) 
                                {
                                    case "Move N":
                                        arm.MoveNorth();
                                        break;
                                    case "Move W":
                                        arm.MoveWest();
                                        break;
                                    case "Move E":
                                        arm.MoveEast();
                                        break;
                                    case "Move S":
                                        arm.MoveSouth();
                                        break;
                                    case "Report":
                                        string outcome = arm.Report();
                                        Console.WriteLine("Output: " + outcome);
                                        break;
                                    case "Drop":
                                        if (arm.Detect() == "FULL")
                                        {
                                            Console.WriteLine("The well is already full");
                                        }
                                        else
                                        {
                                            arm.Drop();
                                        }
                                        break;
                                    case "Detect":
                                        Console.WriteLine(arm.Detect());
                                        break;
                                    default:
                                        Console.WriteLine("Invalid command");
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid command values");
                    }
                }
                catch (IndexOutOfRangeException)//Catching the exception raised
                {
                    Console.WriteLine("Invalid operation and causes pipe to go beyond border, hence ignored");
                }
                catch(Exception ex){
                    Console.WriteLine(ex.Message);
                }
            } while (exitFlag); //Exit on user's command
        }
        public static void Main(string[] args)
        {
           LabPipette program = new LabPipette();
           program.runPipette();
        }
    }
}
