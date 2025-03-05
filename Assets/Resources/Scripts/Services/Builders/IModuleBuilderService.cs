using AlienInvasion.Core.Module;
using UnityEngine;

namespace AlienInvasion.Core.Services.Builders
{
    public interface IModuleBuilderService
    {
        public IModuleBuilderService SetNewModule(ModuleType type);
        public IModuleBuilderService SetFromInstance(LocationModule instance);
        public IModuleBuilderService WithCars(int count);
        public IModuleBuilderService WithLawns(int count);
        public IModuleBuilderService WithBushes(int count);
        public IModuleBuilderService WithTrees(int count);
        public LocationModule Build(Vector3 position, Quaternion rotation, Transform parent);
    }
}