
namespace AlienInvasion.Core.Services.StateMachines.Game
{
    public class GameStateMachine : IGameStateMachine
    {
        public void ChangeState<T>() where T : IGameState
        {
            throw new System.NotImplementedException();
        }
    }
}