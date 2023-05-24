namespace SolucaoErpDomain.Configurations
{
    public interface ITransientDependecy<TService, TImplementation>
        where TService : class
        where TImplementation : class, TService
    {
    }
}