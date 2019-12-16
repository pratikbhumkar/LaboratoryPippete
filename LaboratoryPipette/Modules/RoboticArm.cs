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
        public Well currentPosition = new Well();
        Plate plate = new Plate();
        private int currentX;
        private int currentY;
        public RoboticArm(Plate _plate)
        {
            plate = _plate; //Assigning the plate.
            currentPosition.X = 4; //setting it to 1,1
            currentPosition.Y = 0; //setting it to 1,1
        }
        //Mapping x and y co-ordinates to the actual array positions.
        public string ManipulatePosition(int _x,int _y)
        {
            this.currentX = 5 - _x;
            this.currentY = _y - 1;
            string outcome=""+ this.currentX + ","+ currentY;
            return outcome;
        }
        /*
        Place command. Takes in the x,y cordinates and places the robotic arm over the well.
        */
        public Well Place(int x, int y)
        {
            if (x<=5 && x>=1 && y<=5 && y>=1) //Check for validity.
            {
                ManipulatePosition(x, y);
                Well well = new Well();
                well = plate.LabPlate[this.currentX][this.currentY];
                currentPosition = well;
            }
            else//If invalid throw exception
            {
                throw new IndexOutOfRangeException();
            }
            return currentPosition;
        }
        /*
        Drop command drops the liquid into the well.
        */
        public bool Drop()
        {
            currentPosition.Content=true;
            return currentPosition.Content;
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
                int xpos = currentPosition.X;
                int ypos = currentPosition.Y;
                xpos = xpos - 1;
                currentPosition = plate.LabPlate[xpos][ypos];
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
                int xpos = currentPosition.X;
                int ypos = currentPosition.Y;

                xpos += 1;
                currentPosition = plate.LabPlate[xpos][ypos];
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
                int xpos = currentPosition.X;
                int ypos = currentPosition.Y;

                ypos += 1;
                currentPosition = plate.LabPlate[xpos][ypos];
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
            if (currentPosition.Y > 0) //Check for validity.
            {
                int xpos = currentPosition.X;
                int ypos = currentPosition.Y;

                ypos -= 1;
                currentPosition = plate.LabPlate[xpos][ypos];
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
            return "" + xvalue + "," + yvalue + "," + Detect();
        }
    }
}
