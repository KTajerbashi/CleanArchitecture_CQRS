using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace WebApi.EndPoints.HostExtensions.Configurations;

public static class AddWebApplicationInjections
{
    public static IServiceCollection AddDependencies(this IServiceCollection services,
        params string[] assemblyNamesForSearch)
    {
        var assemblies = GetAssemblies(assemblyNamesForSearch);
        services.AddApplicationServices(assemblies);
        return services;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="assmblyName"></param>
    /// <returns></returns>
    private static List<Assembly> GetAssemblies(string[] assmblyName)
    {

        var assemblies = new List<Assembly>();
        var dependencies = DependencyContext.Default.RuntimeLibraries;
        foreach (var library in dependencies)
        {
            if (IsCandidateCompilationLibrary(library, assmblyName))
            {
                var assembly = Assembly.Load(new AssemblyName(library.Name));
                assemblies.Add(assembly);
            }
        }
        return assemblies;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="assmblyName"></param>
    /// <returns></returns>
    private static List<Assembly> GetAssembly(string assmblyName)
    {

        var assemblies = new List<Assembly>();
        var dependencies = DependencyContext.Default.RuntimeLibraries;
        foreach (var library in dependencies)
        {
            if (IsCandidateCompilationLibrary(library, assmblyName))
            {
                var assembly = Assembly.Load(new AssemblyName(library.Name));
                assemblies.Add(assembly);
            }
        }
        return assemblies;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="compilationLibrary"></param>
    /// <param name="assmblyName"></param>
    /// <returns></returns>

    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assmblyName)
    {
        return assmblyName.Any(d => compilationLibrary.Name.Contains(d))
            || compilationLibrary.Dependencies.Any(d => assmblyName.Any(c => d.Name.Contains(c)));
    }
    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string assmblyName)
      => (compilationLibrary.Name.Contains(assmblyName) || compilationLibrary.Dependencies.Any(d => assmblyName.Equals(d)));
}
