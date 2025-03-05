using UnityEngine;

namespace AlienInvasion.Core
{
    public interface ICameraWrapper
    {
        public Vector3 CurrentPosition {get;}
        public void InitializeCamera(); 
    }
}