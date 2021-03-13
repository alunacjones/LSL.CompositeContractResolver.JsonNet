using System;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICompositeContractResolverBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        CompositeContractResolver Build(Action<ICompositeContractResolverContext> configurator);
    }
}