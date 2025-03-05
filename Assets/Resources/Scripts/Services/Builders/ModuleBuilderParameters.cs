using AlienInvasion.Core.Module;

namespace AlienInvasion.Core.Builders
{
    public struct ModuleBuilderParameters
    {
        public Module.LocationModule Module { get; set; }
        public int CarCount { get; set; }
        public int TreeCount { get; set; }
        public int LawnCount { get; set; }
        public int BushCount { get; set; }
    }
}