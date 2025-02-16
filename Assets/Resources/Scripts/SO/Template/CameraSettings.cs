using UnityEngine;

[CreateAssetMenu(fileName = "New CameraSettings", menuName = "CameraSettings", order = 21)]
public class CameraSettings : ScriptableObject
{
    [SerializeField] private float _horizontalFov;
    [SerializeField] private float _cameraZoom;
    [SerializeField] private float _moveSpeed;

    [SerializeField]
    [Range(0, 1)] private float _matchWidthOrHeight;

    public float MoveSpeed => _moveSpeed;
    public float HorizontalFov => _horizontalFov;
    public float CameraZoom => _cameraZoom;
    public float MatchWidthOrHeight => _matchWidthOrHeight;
}
