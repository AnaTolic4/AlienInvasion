using System.Collections.Generic;
using AlienInvasion.Core.Destruction;
using AlienInvasion.Core.Destruction.Fragment;

namespace AlienInvasion.Core.DestroyableObject.Building
{
    public class BuildingModel : DestroyableObjectModel
    {
        private readonly Dictionary<int, FragmentMemento> _fragmentMementos;

        public BuildingModel(Dictionary<int, IFragment> fragments) : base(fragments)
        {
            _fragmentMementos = new Dictionary<int, FragmentMemento>();
        }

        public override List<IFragment> DetachAllFragments()
        {
            var detachedFragments = new List<IFragment>();

            foreach (var key in Fragments.Keys)
            {
                if (Fragments.TryGetValue(key, out var fragment))
                {
                    detachedFragments.Add(fragment);
                }
            }

            return detachedFragments;
        }

        public override IFragment DetachFragmentByIndex(int index)
        {
            if (Fragments.TryGetValue(index, out var fragment))
            {
                return fragment;
            }
            else
            {
                return null;
            }
        }

        public void SaveFragmentStates()
        {
            foreach (var key in Fragments.Keys)
            {
                if (Fragments.TryGetValue(key, out var fragment))
                {
                    _fragmentMementos[key] = new FragmentMemento(new FragmentState
                    {
                        LocalPosition = fragment.LocalPosition,
                        LocalRotation = fragment.LocalRotation
                    });
                }
            }
        }

        public void ResetFragmentStates()
        {
            foreach (var key in _fragmentMementos.Keys)
            {
                if (_fragmentMementos.TryGetValue(key, out var fragmentMemento))
                {
                    Fragments[key].ResetState(fragmentMemento.State);
                }
            }
        }
    }
}