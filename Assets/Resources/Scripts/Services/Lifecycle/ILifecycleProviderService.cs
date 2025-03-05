namespace AlienInvasion.Core.Services.Lifecycle
{
    public interface ILifecycleProviderService
    {
        public void EnableUpdate(bool value); 
        public void RegisterUpdatable(IUpdatable updatable);
        public void UnregisterUpdatable(IUpdatable updatable);
    }
}