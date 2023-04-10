namespace SolucaoErp.Configuration.ErrorsApi;
public class ResponseData
{
    public bool Successful { get; set; }
    public string Message { get; set; }
    public int codError { get; set; }
    public List<ErrorModel> Error { get; set; } = new List<ErrorModel>();
}