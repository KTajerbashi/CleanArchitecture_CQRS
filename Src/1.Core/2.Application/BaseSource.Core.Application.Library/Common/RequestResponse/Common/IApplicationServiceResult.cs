namespace BaseSource.Core.Application.Library.Common.RequestResponse.Common;
public interface IApplicationServiceResult
{
    IEnumerable<string> Messages { get; }
    ApplicationServiceStatus Status { get; set; }
}
