namespace HyperCasual.Interfaces
{
    /// <summary>
    /// Provides a public interface for any element which requires manual initialization.
    /// </summary>
    public interface IComponentInitializer
    {
        void Initialize();
    }
}
