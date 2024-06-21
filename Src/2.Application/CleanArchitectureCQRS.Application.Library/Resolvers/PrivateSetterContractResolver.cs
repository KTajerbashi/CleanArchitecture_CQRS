using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace CleanArchitectureCQRS.Application.Library.Resolvers;

/// <summary>
/// Custom Contract Resolver to Set Private property when Rehydrate Events
/// </summary>
public class PrivateSetterContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var jsonProperty = base.CreateProperty(member, memberSerialization);

        if (jsonProperty.Writable)
            return jsonProperty;

        if (member is PropertyInfo propertyInfo)
        {
            var setter = propertyInfo.GetSetMethod(true);
            jsonProperty.Writable = setter != null;
        }

        return jsonProperty;
    }
    //EnvironmentVariableTarget jsonProperty = base.CreateProperty();
}
