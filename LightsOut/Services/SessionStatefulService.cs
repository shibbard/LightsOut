using LightsOut.Models;
using LightsOut.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightsOut.Services
{
    /// <summary>
    /// Class to store Lights on data in the current session
    /// </summary>
    public class SessionStatefulService : IStatefulService
    {
        public List<LightModel> LoadState()
        {
            if (HttpContext.Current.Session["lightModels"] != null)
            {
                // purposely keep a reference to the session so it can be modified by the code directly
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