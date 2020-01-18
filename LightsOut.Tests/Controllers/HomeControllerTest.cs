using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightsOut.Interfaces;
using LightsOut.Controllers;
using LightsOutTest.Utils;

namespace LightsOutTests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            controller.statefulService = new InMemStatefulService(); 
            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ClickLight()
        {
            // Arrange
            HomeController controller = new HomeController();
            controller.statefulService = new InMemStatefulService(); 

            // Act
            var result = (RedirectToRouteResult)controller.ClickLight(1);

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}
