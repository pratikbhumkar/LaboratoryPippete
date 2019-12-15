using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratoryPipette.Entities
{
    /*
    Entity representing the Well.
    */
    public class Well
    {
        public int X { get; set; } //X cordinate
        public int Y { get; set; }//Y cordinate
        public bool Content { get; set; } //Content representing the well content. true is full and false is empty.
    }
}
