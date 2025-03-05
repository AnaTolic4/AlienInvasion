using AlienInvasion.Core.DestroyableObject.Building;
using UnityEngine;
using Zenject;
using AlienInvasion.Core.Services.AssetLoader;

namespace AlienInvasion.Core.Services.Factories
{
    public class BuildingFactoryService : IFactoryService<Building, BuildingAssetType>
    {
        private readonly BuildingAssetLoader _assetLoader;
        private readonly DiContainer _container;

        private Building _prefab;

        public BuildingFactoryService(DiContainer container, BuildingAssetLoader assetLoader)
        {
            _container = container;
            _assetLoader = assetLoader;
        }

        public Building Create(Vector3 position, Quaternion rotation, Transform parent)
        {
            return _container.InstantiatePrefabForComponent<Building>(_prefab, position, rotation, parent);
        }

        public void LoadData(BuildingAssetType assetType)
        {
            _prefab = _assetLoader.Load(assetType);
        }
    }
}