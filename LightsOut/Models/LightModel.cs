using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightsOut.Models
{
    public class LightModel
    {
        // Id as key into the item
        public int LightModelId { get; set; }
        // X Coord
        public int X { get; set; }
        // Y Coord
        public int Y { get; set; }
        // Flag to indicate light on or not
        public bool On { get; set; }
    }
}