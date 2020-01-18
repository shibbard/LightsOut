using LightsOut.Models;
using System.Collections.Generic;

namespace LightsOut.Interfaces
{
    public interface IStatefulService
    {
        List<LightModel> LoadState();
        void SaveState(List<LightModel> lightModels);
    }
}