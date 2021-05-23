using System;
using Newtonsoft.Json.Serialization;

namespace LSL.CompositeContractResolver.JsonNet.Configurators
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICreatePropertyConfigurator : IConfigurator<CreatePropertyContractResolverContext, JsonProperty>
    {
    }
}