using System;
using Newtonsoft.Json.Serialization;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPropertyConfigurator : IConfigurator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonProperty"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        JsonProperty Configure(JsonProperty jsonProperty, Func<JsonProperty> next);
    }
}