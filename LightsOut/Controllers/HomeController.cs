using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LightsOut.Models;
using LightsOut.Services;
using LightsOut.Interfaces;

namespace LightsOut.Controllers
{
    public class HomeController : Controller
    {
        // Set the stateful service to be used
        public IStatefulService statefulService = new SessionStatefulService();

        private const int GridSize = 5; // Could be passed in from the UI

        // Main controller for the game
        public ActionResult Index()
        {
            // Create the game service
            var lightsSrv = new LightsOutService(statefulService, GridSize);

            // Create the viewmodel
            LightsOutViewModel lightsOutViewModel = new LightsOutViewModel
            {
                GridSize = GridSize,
                LightModels = lightsSrv.GetGrid()
            };

            return View(lightsOutViewModel);
        }

        // Handler for when a light is clicked
        public ActionResult ClickLight(int id)
        {
            // Get the service object and call the method to set the selected light
            var lightsSrv = new LightsOutService(statefulService);
            lightsSrv.SetLight(id);

            // Redirect back to the main controller
            return RedirectToAction("Index");
        }

    }
}