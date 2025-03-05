using System;
using AlienInvasion.Core.Builders;
using AlienInvasion.Core.Module;
using AlienInvasion.Core.Services.AssetLoaders;
using AlienInvasion.Core.Services.AssetLoaders.ModuleAssetLoader;
using UnityEngine;

namespace AlienInvasion.Core.Services.Builders
{
    public class ModuleBuilderService : IModuleBuilderService
    {
        private readonly LocationModuleAssetLoader _assetLoader;
        private ModuleBuilderParameters _parameters;

        public ModuleBuilderService(LocationModuleAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;
            _parameters = new ModuleBuilderParameters();
        }

        public IModuleBuilderService SetFromInstance(LocationModule instance)
        {
            _parameters.Module = instance;
            return this;
        }

        public IModuleBuilderService SetNewModule(ModuleType type)
        {
            _parameters.Module = _assetLoader.Load(ModuleAssetType.Suburb);
            return this;
        }

        public LocationModule Build(Vector3 position, Quaternion rotation, Transform parent)
        {
            if (_parameters.Module == null)
            {
                throw new NullReferenceException("Set module before build it");
            }

            return GameObject.Instantiate(_parameters.Module, position, rotation, parent);
        }

        public IModuleBuilderService WithBushes(int count)
        {
            _parameters.BushCount = count;
            return this;
        }

        public IModuleBuilderService WithCars(int count)
        {
            _parameters.CarCount = count;
            return this;
        }

        public IModuleBuilderService WithLawns(int count)
        {
            _parameters.LawnCount = count;
            return this;
        }

        public IModuleBuilderService WithTrees(int count)
        {
            _parameters.TreeCount = count;
            return this;
        }
    }
}