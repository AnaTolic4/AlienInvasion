using System.Collections.Generic;
using AlianInvasion.Core.Destruction;
using UnityEngine;

namespace AlianInvasion.Core.DestroyableObject
{
    public abstract class DestroyableObjectModel
    {
        private readonly Dictionary<int, IFragment> _fragments;

        protected IReadOnlyDictionary<int, IFragment> Fragments => _fragments;

        public DestroyableObjectModel(Dictionary<int, IFragment> fragments)
        {
            _fragments = fragments;
        }

        public abstract IFragment DetachFragmentByIndex(int index);
        public abstract List<IFragment> DetachAllFragments();
    }
}