using AlienInvasion.Core.Services.AssetLoader;
using AlienInvasion.Core.Services.Builders;
using AlienInvasion.Core.Services.Factories;
using AlienInvasion.Core.Services.Lifecycle;
using UnityEngine;

namespace AlienInvasion.Core.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private LifecycleProviderService _lifecycleProviderService;

        private void Awake()
        {

        }

    }
}