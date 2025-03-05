using AlienInvasion.Core.Destruction.Fragment;
using UnityEngine;

namespace AlienInvasion.Core.Destruction
{
    public interface IFragmentModel
    {
        public bool IsDetached { get; }
        public float Mass { get; }
        public void Activate();
        public void SetState(FragmentState state, Transform transform);
        public void AddExplosionForce(Vector3 explosivePosition);
        public void InitializeRigidbody(Rigidbody rigidbody);
    }
}