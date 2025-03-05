namespace AlienInvasion.Core.Destruction.Fragment
{
    public class FragmentMemento
    {
        public FragmentState State {get;}

        public FragmentMemento(FragmentState state)
        {
            State = state;
        }
    }
}