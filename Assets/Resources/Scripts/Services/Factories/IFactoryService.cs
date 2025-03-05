using System;
using AlienInvasion.Core.DestroyableObject.Building;
using UnityEngine;

namespace AlienInvasion.Core.Services.Factories
{
    public interface IFactoryService<PrefabT,AssetT> where PrefabT : MonoBehaviour where AssetT: Enum
    {
        public PrefabT Create(Vector3 position, Quaternion quaternion, Transform parent);
        public void LoadData(AssetT assetType);
    }
}