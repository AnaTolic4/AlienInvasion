using UnityEngine;

namespace AlianInvasion.Core.Services.AssetLoader
{
    public class AssetLoaderService: IAssetLoaderService
    {
        private static string DestroyableObjects = "Prefabs/Destroyable";
        private static string LocationBlock = "Prefabs/LocationBlocks"; 
        private static string Settings = "SO/Settings";

        public T LoadLocationBlock<T>() where T: MonoBehaviour
        {
            return Resources.Load<T>(LocationBlock);
        }

        public T LoadDestroyableObject<T>() where T: MonoBehaviour
        {
            return Resources.Load<T>(DestroyableObjects);
        }

        public T LoadSettings<T>() where T: ScriptableObject
        {
            return Resources.Load<T>(Settings);
        }
    }
}