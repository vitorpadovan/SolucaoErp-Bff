namespace SolucaoErpDomain.Configurations
{
    public interface IScopedDependecy<TService, TImplementation>
        where TService : class
        where TImplementation : class, TService
    {
    }
}