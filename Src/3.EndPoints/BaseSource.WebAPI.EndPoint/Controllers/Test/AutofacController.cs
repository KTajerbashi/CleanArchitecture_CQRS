using BaseSource.Utilities.Autofac.Sample;

namespace BaseSource.WebAPI.EndPoint.Controllers.Test;
public class AutofacController : AuthorizeController
{
    private readonly IAutofacSingleton _autofacSingleton;
    private readonly IAutofacScoped _autofacScopedA;
    private readonly IAutofacScoped _autofacScopedB;
    private readonly IAutofacTransient _autofacTransientA;
    private readonly IAutofacTransient _autofacTransientB;

    public AutofacController(
        IAutofacSingleton autofacSingleton, 
        IAutofacScoped autofacScopedA, 
        IAutofacScoped autofacScopedB, 
        IAutofacTransient autofacTransientA, 
        IAutofacTransient autofacTransientB)
    {
        _autofacSingleton = autofacSingleton;
        _autofacScopedA = autofacScopedA;
        _autofacScopedB = autofacScopedB;
        _autofacTransientA = autofacTransientA;
        _autofacTransientB = autofacTransientB;
    }

    [HttpGet("Execute")]
    public async Task<IActionResult> Execute()
    {
        var single = _autofacSingleton.Execute();
        var scopedA = _autofacScopedA.Execute();
        var scopedB = _autofacScopedB.Execute();
        var transientA = _autofacTransientA.Execute();
        var transientB = _autofacTransientB.Execute();
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
