using System.Collections.Generic;
using AlienInvasion.Core.Destruction;
using AlienInvasion.Core.Services.AssetLoader;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace AlienInvasion.Core.DestroyableObject.Building
{
    public class Building : DestroyableObjectPresenter
    {
        [SerializeField] private BuildingAssetType _type;
        private BuildingModel _model;

        public BuildingAssetType AssetType => _type;

        [Inject]
        private void Construct(FragmentParameters fragmentParameters)
        {
            var fragments = new Dictionary<int, IFragment>();
            int currentFragmentIndex = 0;

            foreach (Transform child in transform)
            {
                var fragment = child.AddComponent<FragmentPresenter>();
                var fragmentModel = new FragmentModel(fragmentParameters);

                fragment.Initiaze(fragmentModel, currentFragmentIndex);
                fragments.Add(currentFragmentIndex, fragment);
                currentFragmentIndex++;
            }

            _model = new BuildingModel(fragments);
            _model.SaveFragmentStates();
        }

        public override List<IFragment> DetachAllFragments()
        {
            return _model.DetachAllFragments();
        }

        public override IFragment DetachFragmentByIndex(int index)
        {
            return _model.DetachFragmentByIndex(index);
        }

        public void Restore()
        {
            _model.ResetFragmentStates();
        }
    }
}