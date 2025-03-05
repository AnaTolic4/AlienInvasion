namespace AlienInvasion.Core.Services.StateMachines.Game
{
    public interface IGameState
    {
        public void Enter();
        public void Exit();
    }
}