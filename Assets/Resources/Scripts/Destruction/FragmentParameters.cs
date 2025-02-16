using UnityEngine;

namespace AlianInvasion.Core.Destruction
{
    public struct FragmentParameters
    {
        public float MinMass {get; set;}
        public float MaxMass {get; set;}
        public float ExplosiveForce { get; set; }
        public float ExplosiveRadius { get; set; }
        public float UpwardModifier { get; set; }
        public ForceMode ForceMode {get; set;}
    }
}