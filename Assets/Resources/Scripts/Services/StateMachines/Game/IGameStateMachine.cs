namespace AlienInvasion.Core.Services.StateMachines.Game
{
    public interface IGameStateMachine
    {
        public void ChangeState<T>() where T: IGameState;
    }
}