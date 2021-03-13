using System;
using Newtonsoft.Json.Serialization;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CreateContractContractResolverContext : IContractResolverContext<JsonContract>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="returnValue"></param>
        public CreateContractContractResolverContext(Type objectType, JsonContract returnValue)
        {
            this.ReturnValue = returnValue;
            this.ObjectType = objectType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Type ObjectType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public JsonContract ReturnValue { get; }
    }
}