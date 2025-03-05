using UnityEngine;

namespace AlienInvasion.Core.Services.SettingsLoader
{
    public interface ISettingsLoaderService
    {
        public T Load<T>() where T : ScriptableObject;
    }
}