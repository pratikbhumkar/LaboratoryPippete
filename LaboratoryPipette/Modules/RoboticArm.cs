using LaboratoryPipette.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratoryPipette.Modules
{
    public class RoboticArm
    {
        Well currentPosition = new Well();
        Plate plate = new Plate(5,5);
        private int x;
        private int y;
        public RoboticArm(Plate _plate)
        {
            plate = _plate;
            currentPosition.X = 1;
            currentPosition.Y = 1;
        }

        public void ManipulatePosition(int _x,int _y)
        {
            x = 5 - _x;
            y = _y - 1;
        }
        public void Place(int x, int y)
        {
            if (x<=5 && x>=1 && y<=5 && y>=1)
            {
                ManipulatePosition(x, y);
                currentPosition = plate.LabPlate[this.x][this.y];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }
        public void Drop()
        {
            currentPosition.Content = true;
        }
        public string Detect()
        {
            return currentPosition.Content?"FULL":"EMPTY";
        }
        public void MoveNorth()
        {
            if ( currentPosition.X > 0)
            {
                currentPosition.X -= 1;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            
        }
        public void MoveSouth()
        {
            if (currentPosition.X < 4)
            {
                currentPosition.X += 1;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void MoveEast()
        {
            if (currentPosition.Y < 4)
            {
                currentPosition.Y += 1;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void MoveWest()
        {
            if (currentPosition.Y > 1)
            {
                currentPosition.Y -= 1;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public string Report()
        {
            int xvalue = 5-currentPosition.X;
            int yvalue = currentPosition.Y+1;
            return "" + xvalue + " " + yvalue + " " + Detect();
        }
    }
}
