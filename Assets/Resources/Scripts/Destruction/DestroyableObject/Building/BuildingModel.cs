using System.Collections.Generic;
using AlianInvasion.Core.Destruction;

namespace AlianInvasion.Core.DestroyableObject.Building
{
    public class BuildingModel : DestroyableObjectModel
    {
        public BuildingModel(Dictionary<int,IFragment> fragments) : base(fragments) { }

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
            if(Fragments.TryGetValue(index,out var fragment))
            {
                return fragment;
            }
            else
            {
                return null;
            }
        }
    }
}