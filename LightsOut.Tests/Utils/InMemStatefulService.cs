using LightsOut.Interfaces;
using LightsOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightsOutTest.Utils
{
    public class InMemStatefulService : IStatefulService
    {
        private List<LightModel> _lightModels;
        public List<LightModel> LoadState()
        {
            return _lightModels;
        }
        public void SaveState(List<LightModel> lightModels)
        {
            _lightModels = lightModels;
        }
    }
}