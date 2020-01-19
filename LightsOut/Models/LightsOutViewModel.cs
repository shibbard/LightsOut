using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightsOut.Models
{
    public class LightsOutViewModel
    {
        // Size of the grid to be rendered
        public int GridSize { get; set; }
        // List of light and states
        public List<LightModel> LightModels { get; set; }
    }
}