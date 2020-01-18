using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightsOut.Models
{
    public class LightModel
    {
        public int LightModelId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool On { get; set; }
    }
}