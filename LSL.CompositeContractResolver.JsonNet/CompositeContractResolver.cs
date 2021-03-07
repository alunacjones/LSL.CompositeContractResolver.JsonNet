using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using LSL.CompositeHandlers;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public class CompositeContractResolver : DefaultContractResolver
    {
        private readonly Lazy<Func<IEnumerable<IConfigurator>>> _createPropertyConfigurator;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurators"></param>
        /// <param name="compositeHandlerFactory"></param>
        public CompositeContractResolver(IEnumerable<IConfigurator> configurators, ICompositeHandlerFactory compositeHandlerFactory)
        {
            _createPropertyConfigurator = new Lazy<Func<IEnumerable<IConfigurator>>>(() => compositeHandlerFactory
                .Create(ResolveContextualConfigurators<IPropertyConfigurator>()
                    .Select(new HandlerDelegate<JsonProperty, JsonProperty>(i => i.Configure))))
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        // protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) =>
        //     _createPropertyConfigurator.Value(base.CreateProperty(member, memberSerialization));

        private IEnumerable<T> ResolveContextualConfigurators<T>()
            where T : IConfigurator
        {
            IEnumerable<T> Resolve(IEnumerable<T> c)
            {
                foreach (var item in c)
                {
                    yield return item;
                    if (item.ScopedConfigurators != null)
                    {
                        var childItems = Resolve(item.ScopedConfigurators.OfType<T>());
                        foreach (var childItem in childItems)
                        {
                            yield return childItem;
                        }
                    }
                }
            }

            return Resolve(_configurators.OfType<T>());
        }
    }
}