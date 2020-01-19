using LightsOut.Models;
using LightsOut.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightsOut.Services
{
    /// <summary>
    /// This class provides the main logic and provides services for the Lights Out game
    /// </summary>
    public class LightsOutService
    {
        private int _gridSize = 5; // Default grid size
        private int _randomClicks = 1; // Default random blocks shown at start
        private IStatefulService _statefulService; 

        private List<LightModel> _lightModels; // List of each light to be clicked in the grid

        /// <summary>
        /// LightsOutService constructor
        /// </summary>
        /// <param name="statefulService">Interface that will provide the statefull service for saving/loading the grid</param>
        /// <param name="gridSize">Width and height of the grid defaulted to 5</param>
        /// <param name="randomClicks">Number of random blocks clicked at the start, default to 1</param>
        public LightsOutService(IStatefulService statefulService, int? gridSize = null, int? randomClicks = null)
        {
            _statefulService = statefulService;

            // If grid size passed in set it
            if(gridSize.HasValue)
                _gridSize = gridSize.Value;

            // If number of random lights passed in set it
            if (randomClicks.HasValue)
                _randomClicks = randomClicks.Value;

            // if the current state is empty then initialise the grid
            if (_statefulService.LoadState() == null)
            {
                // Initialise the list of lights object
                _lightModels = new List<LightModel>();

                // initialise grid
                int lightId = 0;
                for (int v = 0; v < _gridSize; v++)
                {
                    for (int h = 0; h < _gridSize; h++)
                    {
                        LightModel lightModel = new LightModel { LightModelId = lightId, X = h, Y = v, On = false };
                        _lightModels.Add(lightModel);
                        lightId++;
                    }
                }

                // Save current grid
                _statefulService.SaveState(_lightModels);

                // Set random lights already clicked
                var rnd = _lightModels.OrderBy(x => Guid.NewGuid()).Take(_randomClicks);
                foreach (var r in rnd)
                    r.On = true; // set single lights on
            }
        }

        /// <summary>
        /// Gets the current grid
        /// </summary>
        /// <returns>Grid data</returns>
        public List<LightModel> GetGrid()
        {
            _lightModels = _statefulService.LoadState();
            return _lightModels;
        }

        /// <summary>
        /// Sets a given light by Id
        /// </summary>
        /// <param name="id">Id of the light to set as clicked</param>
        public void SetLight(int id)
        {
            // Load the grid data
            _lightModels = _statefulService.LoadState();
            // Find the selected light
            var selectedLight = _lightModels.SingleOrDefault(li => li.LightModelId == id);
            if (selectedLight != null)
            {
                int x = selectedLight.X;
                int y = selectedLight.Y;

                // Toggle this light
                ToggleLight(x, y, ref _lightModels);

                // Now toggle the light above
                ToggleLight(x, y - 1, ref _lightModels);

                // left
                ToggleLight(x -1, y, ref _lightModels);

                // right
                ToggleLight(x + 1, y, ref _lightModels);

                // below
                ToggleLight(x, y + 1, ref _lightModels);
            }
        }

        /// <summary>
        /// Toggles a specified light on/off
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <param name="lightModels">Pass in a ref to the grid data</param>
        private void ToggleLight(int x, int y, ref List<LightModel> lightModels)
        {
            // Find the light by the X/Y coords
            var lightAbove = lightModels.SingleOrDefault(li => (li.X == x) && (li.Y == y));

            // If found toggle the on setting
            if (lightAbove != null)
            {
                lightAbove.On = !lightAbove.On;
            }
        }
    }
}