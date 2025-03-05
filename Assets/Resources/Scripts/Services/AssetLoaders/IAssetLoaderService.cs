using System;
using UnityEngine;

namespace AlienInvasion.Core.Services.AssetLoader
{
    public interface IAssetLoaderService<AssetT, ObjectT> where AssetT : MonoBehaviour where ObjectT : Enum
    {
        public AssetT Load(ObjectT type);
    }
}