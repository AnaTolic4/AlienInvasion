using UnityEngine;

namespace AlianInvasion.Core.Services.AssetLoader
{
    public interface IAssetLoaderService : ISettingsLoaderService
    {
        public T LoadDestroyableObject<T>() where T: MonoBehaviour;
    }
}