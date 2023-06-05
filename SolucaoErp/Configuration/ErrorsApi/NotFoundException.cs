namespace SolucaoErp.Configuration.ErrorsApi;
public class NotFoundException : ApiException
{
    public NotFoundException(string? message) : base(message)
    {
    }
}
