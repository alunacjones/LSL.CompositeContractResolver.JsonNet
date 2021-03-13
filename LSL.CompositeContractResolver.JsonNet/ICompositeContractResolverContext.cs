using System;
using System.Collections.Generic;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICompositeContractResolverContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurator"></param>
        /// <param name="contractResolverConfigurator"></param>
        /// <returns></returns>
        ICompositeContractResolverContext AddConfigurator(object contractResolverConfigurator, Action<ICompositeContractResolverContext> configurator = null);
    }
}