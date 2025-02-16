using UnityEngine;

namespace AlianInvasion.Core.Destruction
{
    public interface IFragment
    {
        public int Index {get;}
        public void Detach();
        public void AddExplosiveForce(Vector3 explosiveCenter);
    }
}