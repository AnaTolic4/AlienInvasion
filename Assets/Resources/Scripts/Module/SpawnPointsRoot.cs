using System.Collections.Generic;
using AlienInvasion.Core.Module;
using UnityEngine;

public class SpawnPointsRoot : MonoBehaviour
{
    [SerializeField] private SpawnPointType _spawnType;

    public IEnumerable<Transform> SpawnPoints => (IEnumerable<Transform>)transform; 
}
