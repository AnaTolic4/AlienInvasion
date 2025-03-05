using AlienInvasion.Core.Services.AssetLoader;
using AlienInvasion.Core.Module;

namespace AlienInvasion.Core.Services.AssetLoaders.ModuleAssetLoader
{
    public class LocationModuleAssetLoader : IAssetLoaderService<LocationModule, ModuleAssetType>
    {
        public static string _path = "Prefabs/Modules/";

        public LocationModule Load(ModuleAssetType type)
        {
            throw new System.NotImplementedException();
        }
    }
}