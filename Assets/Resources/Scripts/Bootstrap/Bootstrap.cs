using AlianInvasion.Core.Services.AssetLoader;
using AlianInvasion.Core.Services.Builders;
using AlianInvasion.Core.Services.DI;
using AlianInvasion.Core.Services.Factories;
using AlianInvasion.Core.Services.Lifecycle;
using UnityEngine;

namespace AlianInvasion.Core.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private LifecycleProviderService _lifecycleProviderService;

        private void Awake()
        {
            var container = new DIContainer();

            container.Register<IAssetLoaderService, AssetLoaderService>();
            container.Register<ISettingsLoaderService,AssetLoaderService>();
            container.Register<ILifecycleProviderService, LifecycleProviderService>(_lifecycleProviderService);
            container.Register<ICameraWrapper, CameraWrapper>(new CameraWrapper(_mainCamera, container.GetRequiredEntiry<ISettingsLoaderService>()));

            RegisterBuilders(container);
            RegisterFactories(container);
        }

        private void RegisterBuilders(DIContainer container)
        {
            container.Register<IModuleBlockBuilderService, ModuleBuilderService>();
        }

        private void RegisterFactories(DIContainer container)
        {
            container.Register<IBuildingFactoryService, BuildingFactoryService>();
        }
    }
}