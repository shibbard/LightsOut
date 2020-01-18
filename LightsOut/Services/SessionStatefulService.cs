using LightsOut.Models;
using LightsOut.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightsOut.Services
{
    public class SessionStatefulService : IStatefulService
    {
        public List<LightModel> LoadState()
        {
            if (HttpContext.Current.Session["lightModels"] != null)
            {
                return (List<LightModel>)HttpContext.Current.Session["lightModels"];
            }

            return null;
        }
        public void SaveState(List<LightModel> lightModels)
        {
            HttpContext.Current.Session["lightModels"] = lightModels;
        }
    }
}