using AlienInvasion.Core.Destruction.Fragment;
using UnityEngine;

namespace AlienInvasion.Core.Destruction
{
    public interface IFragment
    {
        public Vector3 LocalPosition { get; }
        public Quaternion LocalRotation { get; }
        public int Index { get; }
        public void ResetState(FragmentState state);
        public void Detach();
        public void AddExplosiveForce(Vector3 explosiveCenter);
    }
}