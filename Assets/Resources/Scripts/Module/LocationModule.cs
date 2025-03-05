using UnityEngine;
using System.Collections.Generic;

namespace AlienInvasion.Core.Module
{
    public class LocationModule : MonoBehaviour
    {
        [SerializeField] private ModuleType _type;
        private List<SpawnPointsRoot> _roots;

        public IEnumerable<SpawnPointsRoot> SpawnPointsRoots => _roots;

        private void Awake()
        {
            _roots = new List<SpawnPointsRoot>();
            
            var spawnPoints = gameObject.GetComponentsInChildren<SpawnPointsRoot>();
            _roots.AddRange(spawnPoints);
        }
    }
}