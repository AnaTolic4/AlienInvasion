using AlianInvasion.Core.Services.Lifecycle;

namespace AlianInvasion.Core.Scripts
{
    public class Game: IUpdatable
    {
        private readonly CameraWrapper _camera;
        private readonly ILifecycleProviderService _lifecycle;

        public Game(CameraWrapper cameraWrapper,ILifecycleProviderService lifecycleProvider)
        {
            _lifecycle = lifecycleProvider;
            _camera = cameraWrapper;
        }

        public void Initialize()
        {
            _camera.InitializeCamera();
        }

        public void Start()
        {
            
        }

        public void Pause()
        {
            _lifecycle.EnableUpdate(false);
        }

        public void Unpause()
        {
            _lifecycle.EnableUpdate(true);
        }

        public void Update()
        {
            
        }
    }
}