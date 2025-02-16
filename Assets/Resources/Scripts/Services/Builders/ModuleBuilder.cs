using AlianInvasion.Core.Services.AssetLoader;

namespace AlianInvasion.Core.Services.Builders
{
    public class ModuleBuilderService : IModuleBlockBuilderService
    {
        private readonly IAssetLoaderService _assetLoader;

        public ModuleBuilderService(IAssetLoaderService assetLoader)
        {
            _assetLoader = assetLoader;
        }

        
    }
}