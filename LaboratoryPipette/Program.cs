using LaboratoryPipette.Entities;
using LaboratoryPipette.Modules;
using System;

namespace LaboratoryPipette
{
    class Program
    {
        public bool placed = false;
        public void PlacePipe(string command, RoboticArm arm)
        {
            command = command.Replace("Place", "");
            var cordinates = command.Split(",");
            if (cordinates.Length == 2)
            {
                arm.Place(int.Parse(cordinates[0].Trim()), int.Parse(cordinates[1].Trim()));
                placed = true;
            }
            else
            {
                Console.WriteLine("Invalid values");
            }
        }
        static void Main(string[] args)
        {
            Plate plate = new Plate(5, 5);
            RoboticArm arm = new RoboticArm(plate);
            Program program = new Program();
            bool exitFlag = true;
            do
            {
                Console.WriteLine("Enter your command");
                Console.WriteLine("Type exit to Exit the program");
                String command=Console.ReadLine();
                try
                {
                    if (!program.placed)
                {
                    if (command.StartsWith("Place"))
                    {
                            program.PlacePipe(command, arm);
                    }
                    else
                    {
                        Console.WriteLine("First command must be a place");
                    }
                }
                else if(program.placed)
                {
                    if (command == "Exit")
                    {
                        exitFlag = false;
                    }
                    else
                    {
                        if (command.StartsWith("Place"))
                        {
                                program.PlacePipe(command, arm);
                        }
                       
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
                                    Console.WriteLine("Invalid input");
                                    break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command values");
                }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid operation and causes pipe to go beyond border, hence ignored");
                }
            } while (exitFlag);
        }
    }
}
