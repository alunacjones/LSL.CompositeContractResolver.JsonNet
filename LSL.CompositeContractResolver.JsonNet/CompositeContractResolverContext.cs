using System;
using System.Collections.Generic;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    internal class CompositeContractResolverContext : ICompositeContractResolverContext
    {
        public CompositeContractResolverContext()
        {
            Configurators = new List<ConfiguratorAndChildContext>();
        }

        internal List<ConfiguratorAndChildContext> Configurators { get; }

        public ICompositeContractResolverContext AddConfigurator(object contractResolverConfigurator, Action<ICompositeContractResolverContext> configurator = null)
        {
            var childContext = new CompositeContractResolverContext();
            configurator?.Invoke(childContext);

            Configurators.Add(new ConfiguratorAndChildContext(contractResolverConfigurator, childContext));
            
            return this;
        }

        internal struct ConfiguratorAndChildContext
        {
            internal ConfiguratorAndChildContext(object configurator, CompositeContractResolverContext childContext)
            {
                Configurator = configurator;
                ChildContext = childContext;
            }

            public object Configurator { get; }
            public CompositeContractResolverContext ChildContext { get; }
        }
    }
}