using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using LSL.CompositeHandlers;
using static LSL.CompositeContractResolver.JsonNet.CompositeContractResolverContext;
using LSL.CompositeContractResolver.JsonNet.Configurators;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CompositeContractResolver : DefaultContractResolver
    {
        private readonly Lazy<Func<CreatePropertyContractResolverContext, JsonProperty>> _createPropertyConfigurator;
        private readonly Lazy<Func<CreateContractContractResolverContext, JsonContract>> _createContractConfigurator;
        private readonly CompositeContractResolverContext _context;
        private readonly ICompositeHandlerFactory _compositeHandlerFactory;

        internal CompositeContractResolver(CompositeContractResolverContext context, ICompositeHandlerFactory compositeHandlerFactory)
        {
            _context = context;
            _compositeHandlerFactory = compositeHandlerFactory;

            _createPropertyConfigurator = CreateLazyCompoundConfigurator<CreatePropertyContractResolverContext, JsonProperty, IPropertyConfigurator>();
            _createContractConfigurator = CreateLazyCompoundConfigurator<CreateContractContractResolverContext, JsonContract, ICreateContractConfigurator>();
        }

        private Lazy<Func<TContext, TJsonEntity>> CreateLazyCompoundConfigurator<TContext, TJsonEntity, TConfigurator>() 
            where TContext : IContractResolverContext<TJsonEntity>
            where TConfigurator : IConfigurator<TJsonEntity>
        { 
            return new Lazy<Func<TContext, TContext>>(() => _compositeHandlerFactory
                .Create(ResolveContextualConfigurators<TConfigurator, TJsonEntity>()
                    .Select(i => new HandlerDelegate<TContext, TJsonEntity>(i.Configure))
                )
            );
        }

        /// <inheritdoc/>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) =>
            _createPropertyConfigurator.Value(
                new CreatePropertyContractResolverContext(
                    base.CreateProperty(member, memberSerialization), 
                    member, 
                    memberSerialization, 
                    member as PropertyInfo
                )
            );

        /// <inheritdoc/>
        protected override JsonContract CreateContract(Type objectType) =>
            _createContractConfigurator.Value(
                new CreateContractContractResolverContext(
                    objectType, 
                    base.CreateContract(objectType)
                )
            );

        private IEnumerable<TConfigurator> ResolveContextualConfigurators<TConfigurator, TJsonEntity>()
            where TConfigurator : IConfigurator<TJsonEntity>
        {
            IEnumerable<ConfiguratorAndChildContext> FilterForType(IEnumerable<ConfiguratorAndChildContext> configurators) => 
                configurators.Where(co => co.Configurator is IConfigurator<TJsonEntity>);

            IEnumerable<TConfigurator> Resolve(IEnumerable<ConfiguratorAndChildContext> c)
            {
                foreach (var item in c)
                {
                    yield return (TConfigurator)item.Configurator;
                    
                    var childItems = Resolve(FilterForType(item.ChildContext.Configurators));
                    foreach (var childItem in childItems)
                    {
                        yield return childItem;
                    }
                }
            }

            return Resolve(FilterForType(_context.Configurators));
        }
    }
}