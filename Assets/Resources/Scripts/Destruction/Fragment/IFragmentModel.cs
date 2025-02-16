using UnityEngine;

namespace AlianInvasion.Core.Destruction
{
    public interface IFragmentModel
    {
        public bool IsDetached {get;}
        public float Mass {get;}
        public void SetGravityState(bool value);
        public void AddExplosionForce(Vector3 explosivePosition);
        public bool TryActivateRigidbody(GameObject gameObject);
    }
}