using System;
using LSL.CompositeHandlers;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public class CompositeConCompositeContractResolverBuilder : ICompositeContractResolverBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public CompositeContractResolver Build(Action<ICompositeContractResolverContext> configurator)
        {
            var context = new CompositeContractResolverContext();
            configurator?.Invoke(context);
            
            return new CompositeContractResolver(context, new CompositeHandlerFactory());
        }
    }
}