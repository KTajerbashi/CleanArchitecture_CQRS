namespace BaseSource.WebAPI.EndPoint.Middleware.ExceptionHandler;

public class ApiErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public IEnumerable<string> Errors { get; set; }
}
