using UnityEngine;

[CreateAssetMenu(fileName = "New Frament", menuName = "Fragment",order = 19)]
public class Fragment : ScriptableObject
{
    [SerializeField] private float _minlMass;
    [SerializeField] private float _maxMass;

    public float MinMass => _minlMass;
    public float MaxMass => _maxMass;
}
