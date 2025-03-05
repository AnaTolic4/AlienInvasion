using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AlienInvasion.Core.Services.SettingsLoader
{
    public class SettingsLoaderService : ISettingsLoaderService
    {
        private static string path = "SO/";

        private List<ScriptableObject> _settings;

        public SettingsLoaderService()
        {
            _settings = new List<ScriptableObject>();
        }

        public T Load<T>() where T : ScriptableObject
        {
            if(_settings.Count == 0)
            {
                var settings = Resources.LoadAll<ScriptableObject>(path);
                _settings.AddRange(settings);

                return (T)_settings.FirstOrDefault(s => s is T);
            }
            else
            {
                return (T)_settings.FirstOrDefault(s => s is T);
            }
        }
    }
}