using UnityEngine;

namespace AlianInvasion.Core.Services.AssetLoader
{
    public interface ISettingsLoaderService
    {
        public T LoadSettings<T>() where T: ScriptableObject;
    }
}