namespace AlianInvasion.Core.Services.DI
{
    public interface IServiceCollection
    {
        public T GetRequiredEntiry<T>() where T : class;
    }
}