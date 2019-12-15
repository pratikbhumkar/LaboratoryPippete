using System;
using System.Collections.Generic;

namespace LaboratoryPipette.Entities
{
    public class Plate
    {
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
        public List<List<Well>> LabPlate = new List<List<Well>>();
    }
}
