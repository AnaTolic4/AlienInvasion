using AlienInvasion.Core.Destruction.Fragment;
using UnityEngine;

namespace AlienInvasion.Core.Destruction
{
    public class FragmentModel : IFragmentModel
    {
        private readonly FragmentParameters _parameters;

        private float _mass;
        private Rigidbody _rigidbody;
        private bool _isDetached;

        public float Mass => _mass;
        public bool IsDetached => _isDetached;

        public FragmentModel(FragmentParameters parameters)
        {
            _parameters = parameters;
            _isDetached = false;
        }

        public void InitializeRigidbody(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

            var sizeMagnitude = _rigidbody.GetComponent<Collider>().bounds.size.magnitude;
            _mass = Mathf.Clamp(sizeMagnitude, _parameters.MinMass, _parameters.MaxMass);

            _rigidbody.mass = _mass;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        public void AddExplosionForce(Vector3 explosivePosition)
        {
            if (_isDetached)
            {
                _rigidbody.AddExplosionForce(_parameters.ExplosiveForce
                , explosivePosition
                , _parameters.ExplosiveRadius
                , _parameters.UpwardModifier
                , _parameters.ForceMode);
            }
        }

        public void SetState(FragmentState state, Transform transform)
        {
            Deactivate();

            transform.localPosition = state.LocalPosition;
            transform.localRotation = state.LocalRotation;

            _isDetached = false;
        }

        public void Activate()
        {
            _rigidbody.useGravity = true;
            _rigidbody.constraints = RigidbodyConstraints.None;
            
            _isDetached = true;
        }

        private void Deactivate()
        {
            _rigidbody.useGravity = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}