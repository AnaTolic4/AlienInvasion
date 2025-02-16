using System.Collections.Generic;
using AlianInvasion.Core.Destruction;
using UnityEngine;

namespace AlianInvasion.Core.DestroyableObject
{
    public abstract class DestroyableObjectPresenter : MonoBehaviour
    {
        [SerializeField] private DestroyableObjectView _view;

        public abstract IFragment DetachFragmentByIndex(int index);
        public abstract List<IFragment> DetachAllFragments();
    }
}

