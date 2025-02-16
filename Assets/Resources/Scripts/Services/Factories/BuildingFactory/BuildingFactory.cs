using System.Collections.Generic;
using AlianInvasion.Core.DestroyableObject.Building;
using AlianInvasion.Core.Destruction;
using Unity.VisualScripting;
using UnityEngine;
using AlianInvasion.Core.Services.AssetLoader;

namespace AlianInvasion.Core.Services.Factories
{
    public class BuildingFactoryService : IBuildingFactoryService
    {
        private readonly AssetLoaderService _assetLoader;

        private FragmentParameters _fragmentParameters;
        private Building _prefab;

        public BuildingFactoryService(AssetLoaderService assetLoader)
        {
            _assetLoader = assetLoader;
        }

        public Building Create(Vector3 position, Quaternion quaternion)
        {
            var building = Object.Instantiate(_prefab, position, quaternion);

            var fragments = new Dictionary<int, IFragment>();
            int currentFragmentIndex = 0;

            foreach (Transform child in building.transform)
            {
                var fragment = child.AddComponent<FragmentPresenter>();
                var fragmentModel = new FragmentModel(_fragmentParameters);

                fragment.Initiaze(fragmentModel, currentFragmentIndex);
                fragments.Add(currentFragmentIndex, fragment);
                currentFragmentIndex++;
            }

            var buidldingModel = new BuildingModel(fragments);
            building.Initialize(buidldingModel);

            return building;
        }

        public void LoadData()
        {
            _prefab = _assetLoader.LoadDestroyableObject<Building>();
        }
    }
}