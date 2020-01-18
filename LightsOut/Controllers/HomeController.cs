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
        public IStatefulService statefulService = new SessionStatefulService();
        public ActionResult Index()
        {
            var lightsSrv = new LightsOutService(statefulService);

            LightsOutViewModel lightsOutViewModel = new LightsOutViewModel
            {
                GridSize = 5,
                LightModels = lightsSrv.GetGrid()
            };

            return View(lightsOutViewModel);
        }

        public ActionResult ClickLight(int id)
        {
            var lightsSrv = new LightsOutService(statefulService);
            lightsSrv.SetLight(id);

            return RedirectToAction("Index");
        }

    }
}