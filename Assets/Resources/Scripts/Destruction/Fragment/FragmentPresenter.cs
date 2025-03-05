using AlienInvasion.Core.Destruction.Fragment;
using UnityEngine;

namespace AlienInvasion.Core.Destruction
{
    public class FragmentPresenter : MonoBehaviour, IFragment
    {
        private int _index;
        private IFragmentModel _model;

        public int Index => _index;

        public Vector3 LocalPosition => transform.localPosition;

        public Quaternion LocalRotation => transform.localRotation;

        public void Initiaze(IFragmentModel model, int index)
        {
            _index = index;
            _model = model;

            var rb = gameObject.AddComponent<Rigidbody>();
            _model.InitializeRigidbody(rb);
        }

        public void Detach()
        {
            _model.Activate();
        }

        public void AddExplosiveForce(Vector3 explosionCenter)
        {
            _model.AddExplosionForce(explosionCenter);
        }

        public void ResetState(FragmentState state)
        {
            _model.SetState(state, transform);
        }
    }
}