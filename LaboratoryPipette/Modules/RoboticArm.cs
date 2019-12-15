using LaboratoryPipette.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratoryPipette.Modules
{
    /*
    Class representing robotic arm.
    */
    public class RoboticArm
    {
        //Current position representing the well over which the arm is pointing.
        Well currentPosition = new Well();
        Plate plate = null;
        private int x;
        private int y;
        public RoboticArm(Plate _plate)
        {
            plate = _plate; //Assigning the plate.
            currentPosition.X = 4; //setting it to 1,1
            currentPosition.Y = 0; //setting it to 1,1
        }
        //Mapping x and y co-ordinates to the actual array positions.
        public void ManipulatePosition(int _x,int _y)
        {
            x = 5 - _x;
            y = _y - 1;
        }
        /*
        Place command. Takes in the x,y cordinates and places the robotic arm over the well.
        */
        public void Place(int x, int y)
        {
            if (x<=5 && x>=1 && y<=5 && y>=1) //Check for validity.
            {
                ManipulatePosition(x, y); 
                currentPosition = plate.LabPlate[this.x][this.y];
            }
            else//If invalid throw exception
            {
                throw new IndexOutOfRangeException();
            }

        }
        /*
        Drop command drops the liquid into the well.
        */
        public void Drop()
        {
            currentPosition.Content = true;
        }
        /*
        Detect command Detects the liquid's status for the current well.
        Returns the string indicating Full or Empty.
        */
        public string Detect()
        {
            return currentPosition.Content?"FULL":"EMPTY";
        }
         /*
        MoveNorth command moves the robotic arm one step in upward direction.
        */
        public void MoveNorth()
        {
            if ( currentPosition.X > 0) //Check for validity.
            {
                currentPosition.X -= 1;
            }
            else//If invalid throw exception
            {
                throw new IndexOutOfRangeException();
            }
            
        }
        /*
        MoveSouth command moves the robotic arm one step in downward direction.
        */
        public void MoveSouth()
        {
            if (currentPosition.X < 4) //Check for validity.
            {
                currentPosition.X += 1;
            }
            else//If invalid throw exception
            {
                throw new IndexOutOfRangeException();
            }
        }
        /*
        MoveEast command moves the robotic arm one step in Right direction.
        */
        public void MoveEast()
        {
            if (currentPosition.Y < 4) //Check for validity.
            {
                currentPosition.Y += 1;
            }
            else//If invalid throw exception
            {
                throw new IndexOutOfRangeException();
            }
        }
        /*
        MoveWest command moves the robotic arm one step in Left direction.
        */
        public void MoveWest()
        {
            if (currentPosition.Y > 1) //Check for validity.
            {
                currentPosition.Y -= 1;
            }
            else//If invalid throw exception
            {
                throw new IndexOutOfRangeException();
            }
        }
        /*
        Report command creates a report for the current well.
        Returns a string with X, Y cordinate and well status(Full/Empty).
        */
        public string Report()
        {
            int xvalue = 5-currentPosition.X;
            int yvalue = currentPosition.Y+1;
            return "" + xvalue + " " + yvalue + " " + Detect();
        }
    }
}
