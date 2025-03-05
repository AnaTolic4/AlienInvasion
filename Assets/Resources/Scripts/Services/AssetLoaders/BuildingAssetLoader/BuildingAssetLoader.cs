using System.Collections.Generic;
using System.Linq;
using AlienInvasion.Core.DestroyableObject.Building;
using UnityEngine;

namespace AlienInvasion.Core.Services.AssetLoader
{
    public class BuildingAssetLoader : IAssetLoaderService<Building, BuildingAssetType>
    {
        private static string path = "Prefabs/Buidldings/";

        private readonly List<Building> _buildings;

        public BuildingAssetLoader()
        {
            _buildings = new List<Building>();
        }

        public Building Load(BuildingAssetType type)
        {
            if (_buildings.Count == 0)
            {
                var buildings = Resources.LoadAll<Building>(path).ToList();
                _buildings.AddRange(buildings);

                return _buildings.FirstOrDefault(b => b.AssetType == type);
            }
            else
            {
                return _buildings.FirstOrDefault(b => b.AssetType == type);
            }

        }
    }
}