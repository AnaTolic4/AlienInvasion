using System.Collections.Generic;
using UnityEngine;

namespace AlianInvasion.Core.Services.Lifecycle
{
    public class LifecycleProviderService : MonoBehaviour, ILifecycleProviderService
    {
        private LinkedList<IUpdatable> _updatables;
        private bool _isUpdatingEnabled;

        private void Awake()
        {
            _updatables = new LinkedList<IUpdatable>();
            _isUpdatingEnabled = false;
        }

        private void Update()
        {
            if(_isUpdatingEnabled)
            {
                foreach (var updatable in _updatables)
                {
                    updatable.Update();
                }
            }
        }

        public void EnableUpdate(bool value)
        {
            _isUpdatingEnabled = value;
        }

        public void RegisterUpdatable(IUpdatable updatable)
        {
            if(!_updatables.Contains(updatable))
            {
                _updatables.AddLast(updatable);
            }
        }

        public void UnregisterUpdatable(IUpdatable updatable)
        {
            if(_updatables.Contains(updatable))
            {
                _updatables.Remove(updatable);
            }
        }
    }
}
