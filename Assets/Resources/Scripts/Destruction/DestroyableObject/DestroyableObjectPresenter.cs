using System.Collections.Generic;
using AlienInvasion.Core.Destruction;
using UnityEngine;

namespace AlienInvasion.Core.DestroyableObject
{
    public abstract class DestroyableObjectPresenter : MonoBehaviour
    {
        public abstract IFragment DetachFragmentByIndex(int index);
        public abstract List<IFragment> DetachAllFragments();
    }
}

