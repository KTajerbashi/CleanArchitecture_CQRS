using BaseSource.Utilities.Scrutor.Sample;

namespace BaseSource.WebAPI.EndPoint.Controllers.Test;

public class ScrutorController : AuthorizeController
{
    private readonly ISingleton _singleton;
    private readonly IScoped _scopedA;
    private readonly IScoped _scopedB;
    private readonly ITransient _transientA;
    private readonly ITransient _transientB;
    public ScrutorController(ISingleton singleton, IScoped scopedA, IScoped scopedB, ITransient transientA, ITransient transientB)
    {
        _singleton = singleton;
        _scopedA = scopedA;
        _scopedB = scopedB;
        _transientA = transientA;
        _transientB = transientB;
    }


    [HttpGet("Execute")]
    public async Task<IActionResult> Execute()
    {
        var single = _singleton.Execute();
        var scopedA = _scopedA.Execute();
        var scopedB = _scopedB.Execute();
        var transientA = _transientA.Execute();
        var transientB = _transientB.Execute();
        await Task.CompletedTask;
        return ReturnResponse(new
        {
            single,
            scopedA,
            scopedB,
            transientA,
            transientB
        });
    }

}
