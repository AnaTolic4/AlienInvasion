using AlianInvasion.Core.DestroyableObject.Building;
using UnityEngine;

namespace AlianInvasion.Core.Services.Factories
{
    public interface IBuildingFactoryService
    {
        public Building Create(Vector3 position, Quaternion quaternion);
        public void LoadData();
    }
}