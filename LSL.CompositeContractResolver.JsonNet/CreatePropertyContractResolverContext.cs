using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CreatePropertyContractResolverContext : IContractResolverContext<JsonProperty>
    {
        internal CreatePropertyContractResolverContext(JsonProperty returnValue, MemberInfo memberInfo, MemberSerialization memberSerialization, PropertyInfo propertyInfo)
        {
            ReturnValue = returnValue;
            MemberInfo = memberInfo;
            MemberSerialization = memberSerialization;
            PropertyInfo = propertyInfo;
        }

        /// <inheritdoc/>
        public JsonProperty ReturnValue { get; }        

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public MemberInfo MemberInfo { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public MemberSerialization MemberSerialization { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public PropertyInfo PropertyInfo { get; }
    }
}