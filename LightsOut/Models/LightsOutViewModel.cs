using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightsOut.Models
{
    public class LightsOutViewModel
    {
        public int GridSize { get; set; }
        public List<LightModel> LightModels { get; set; }
    }
}