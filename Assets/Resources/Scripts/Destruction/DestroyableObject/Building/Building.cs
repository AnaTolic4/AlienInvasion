using System.Collections.Generic;
using AlianInvasion.Core.Destruction;
using UnityEngine;

namespace AlianInvasion.Core.DestroyableObject.Building
{
    public class Building : DestroyableObjectPresenter
    {
        private BuildingModel _model;

        public void Initialize(BuildingModel model)
        {
            _model = model;
        }

        public override List<IFragment> DetachAllFragments()
        {
            return _model.DetachAllFragments();
        }

        public override IFragment DetachFragmentByIndex(int index)
        {
            return _model.DetachFragmentByIndex(index);
        }
    }
}