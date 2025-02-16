using UnityEngine;

namespace AlianInvasion.Core.Destruction
{
    public class FragmentPresenter : MonoBehaviour, IFragment
    {
        private int _index;
        private IFragmentModel _model;

        public int Index => _index;

        public void Initiaze(IFragmentModel model, int index)
        {
            _index = index;
            _model = model;
        }

        public void Detach()
        {
            _model.TryActivateRigidbody(gameObject);
        }

        public void AddExplosiveForce(Vector3 explosionCenter)
        {
            _model.AddExplosionForce(explosionCenter);
        }
    }
}