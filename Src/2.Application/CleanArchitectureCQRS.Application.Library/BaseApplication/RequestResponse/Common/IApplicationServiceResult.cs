namespace CleanArchitectureCQRS.Application.Library.BaseApplication.RequestResponse.Common;
public interface IApplicationServiceResult
{
    IEnumerable<string> Messages { get; }
    ApplicationServiceStatus Status { get; set; }
}
