namespace SolucaoErpDomain.Configurations
{
    public interface ISingletonDependecy<TService, TImplementation> 
        where TService : class 
        where TImplementation : class, TService
    {
    }
}