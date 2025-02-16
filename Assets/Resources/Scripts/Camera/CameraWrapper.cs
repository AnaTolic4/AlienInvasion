using AlianInvasion.Core.Services.AssetLoader;
using AlianInvasion.Core.Services.Lifecycle;
using UnityEngine;

namespace AlianInvasion.Core
{
    public class CameraWrapper : ICameraWrapper, IUpdatable
    {
        private readonly Camera _camera;
        private readonly ISettingsLoaderService _settingsLoader;

        private CameraSettings _settings;
        private float _targetAspect;
        private float _initialVerticalFov;
        private float _horizontalFov;

        public Vector3 CurrentPosition => _camera.transform.position;

        public CameraWrapper(Camera camera, ISettingsLoaderService settingsLoaderService)
        {
            _camera = camera;
            _settingsLoader = settingsLoaderService;

        }

        public void InitializeCamera()
        {
            _settings = _settingsLoader.LoadSettings<CameraSettings>();

            _targetAspect = Screen.width / Screen.height;
            _initialVerticalFov = _camera.fieldOfView;
            _horizontalFov = CalculateFov(_initialVerticalFov, 1 / _targetAspect);

            SetCameraFov();
        }

        public void Update()
        {
            _camera.transform.Translate(_settings.MoveSpeed * Time.deltaTime * Vector3.left, Space.World);
        }

        private void SetCameraFov()
        {
            float constWidthFoV = CalculateFov(_horizontalFov, _camera.aspect);
            _camera.fieldOfView = Mathf.Lerp(constWidthFoV, _initialVerticalFov, _settings.MatchWidthOrHeight) * _settings.CameraZoom;

            float currentHorizontalFov = GetCurrentHorizontalFov();
            SetCameraPosition(currentHorizontalFov);
        }

        private void SetCameraPosition(float currentHorizontalFow)
        {
            float cameraStep = currentHorizontalFow - _settings.HorizontalFov;

            Vector3 nextPosition = _camera.transform.position;
            nextPosition.y -= cameraStep;
            _camera.transform.position = nextPosition;
        }

        private float CalculateFov(float cameraFov, float aspect)
        {
            var horizontalFovInRad = cameraFov * Mathf.Deg2Rad;
            var verticalFovInRad = 2 * Mathf.Atan(Mathf.Tan(horizontalFovInRad / 2) / aspect);

            return verticalFovInRad * Mathf.Rad2Deg;
        }

        private float GetCurrentHorizontalFov()
        {
            var angleInRad = _camera.fieldOfView * Mathf.Deg2Rad;
            var horizontalFoVInRad = 2 * Mathf.Atan(Mathf.Tan(angleInRad / 2) * _camera.aspect);

            return horizontalFoVInRad * Mathf.Rad2Deg;
        }
    }
}