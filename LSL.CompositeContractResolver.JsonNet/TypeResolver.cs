using System;
using System.Collections.Generic;
using LSL.CompositeContractResolver.JsonNet.Configurators;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public class TypeResolver : BaseResolver, ICreateContractConfigurator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typesToRestrictTo"></param>
        /// <returns></returns>
        public static TypeResolver For(IEnumerable<Type> typesToRestrictTo) => new TypeResolver(typesToRestrictTo);

        private readonly IEnumerable<Type> _typesToRestrictTo;

        internal TypeResolver(IEnumerable<Type> typesToRestrictTo)
        {
            _typesToRestrictTo = typesToRestrictTo;
        }

        /// <inheritdoc/>
        public JsonContract Configure(CreateContractContractResolverContext createPropertyContext, Func<JsonContract> next) => 
            _typesToRestrictTo.Contains(createPropertyContext.ObjectType) ? next() : createPropertyContext.ReturnValue;
    }
}