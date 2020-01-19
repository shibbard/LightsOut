using LightsOut.Interfaces;
using LightsOut.Services;
using LightsOutTest.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LightsOutTest.Services
{
    [TestClass]
    public class LightsOutServiceTests
    {
        private IStatefulService _statefulService = new InMemStatefulService();

        [TestMethod]
        public void TestGridInit()
        {
            // gird is 5 by 5 as default, expect grid size to equal 25
            int expectedGridSize = 25;

            LightsOutService lightsOutService = new LightsOutService(_statefulService);

            var grid = lightsOutService.GetGrid();

            Assert.AreEqual(expectedGridSize, grid.Count());
        }

        [TestMethod]
        public void TestSetLight()
        {
            // gird is 5 by 5 as default, setting light 7, expect 7, 2, 6, 8, 12 to be on

            LightsOutService lightsOutService = new LightsOutService(_statefulService, 5, 0);

            lightsOutService.SetLight(7);

            var grid = lightsOutService.GetGrid();

            var grid7 = grid.Single(gr => gr.LightModelId == 7);
            var grid2 = grid.Single(gr => gr.LightModelId == 2);
            var grid6 = grid.Single(gr => gr.LightModelId == 6);
            var grid8 = grid.Single(gr => gr.LightModelId == 8);
            var grid12 = grid.Single(gr => gr.LightModelId == 12);

            Assert.IsTrue(grid7.On);
            Assert.IsTrue(grid2.On);
            Assert.IsTrue(grid6.On);
            Assert.IsTrue(grid8.On);
            Assert.IsTrue(grid12.On);
        }
    }

}
