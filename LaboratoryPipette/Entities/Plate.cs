using System;
using System.Collections.Generic;

namespace LaboratoryPipette.Entities
{
    /*
    Entity representing the plate.
    */
    public class Plate
    {
        public Plate()
        {

        }
        /*
        Constructor to create the plate.
        */
        public Plate(int length, int breadth)
        {
            for (int i = 0; i < length; i++)
            {
                List<Well> row = new List<Well>();
                for (int j = 0; j < breadth; j++)
                {
                    Well well = new Well
                    {
                        X = i,
                        Y = j
                    };
                    row.Add(well);
                }
                LabPlate.Add(row);
            }
        }
        /*
        2 Dimentional array storing the plate.
        */
        public List<List<Well>> LabPlate = new List<List<Well>>();
    }
}
