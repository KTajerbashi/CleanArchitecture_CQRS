using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace BaseSource.EndPoint.WebApi.HostExtensions.Configurations;

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

    public static IServiceCollection AddWithTransientLifetime(
        this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch,
        params Type[] assignableTo)
    {
        services
            .Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        return services;
    }


    public static IServiceCollection AddWithScopedLifetime(this IServiceCollection services,
   IEnumerable<Assembly> assembliesForSearch,
   params Type[] assignableTo)
    {
        services.Scan(s => s.FromAssemblies(assembliesForSearch)
            .AddClasses(c => c.AssignableToAny(assignableTo))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="compilationLibrary"></param>
    /// <param name="assmblyName"></param>
    /// <returns></returns>

    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string[] assemblyName)
    {
        return assemblyName.Any(d => compilationLibrary.Name.Contains(d))
            || compilationLibrary.Dependencies.Any(d => assemblyName.Any(c => d.Name.Contains(c)));
    }
    private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary, string assmblyName)
      => compilationLibrary.Name.Contains(assmblyName) || compilationLibrary.Dependencies.Any(d => assmblyName.Equals(d));

}
