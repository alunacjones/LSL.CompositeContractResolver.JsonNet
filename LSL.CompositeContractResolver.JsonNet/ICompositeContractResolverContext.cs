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
        /// <param name="resolver"></param>
        /// <param name="configurator"></param>
        /// <returns></returns>
        ICompositeContractResolverContext AddResolver(BaseResolver resolver, Action<ICompositeContractResolverContext> configurator = null);
    }
}