using UnityEngine;

namespace AlianInvasion.Core.Destruction
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

        public void SetGravityState(bool value)
        {
            _rigidbody.useGravity = value;
        }

        public bool TryActivateRigidbody(GameObject gameObject)
        {
            if (_rigidbody == null)
            {
                _rigidbody = gameObject.AddComponent<Rigidbody>();
                _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
                _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;

                var calcMass = _rigidbody.GetComponent<Collider>().bounds.size.magnitude;
                _mass = Mathf.Clamp(calcMass, _parameters.MinMass, _parameters.MaxMass);
                _rigidbody.mass = _mass;

                _isDetached = true;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddExplosionForce(Vector3 explosivePosition)
        {
            if (_isDetached)
            {
                _rigidbody.AddExplosionForce(_parameters.ExplosiveForce
                ,explosivePosition
                ,_parameters.ExplosiveRadius
                ,_parameters.UpwardModifier
                ,_parameters.ForceMode);
            }
        }
    }
}