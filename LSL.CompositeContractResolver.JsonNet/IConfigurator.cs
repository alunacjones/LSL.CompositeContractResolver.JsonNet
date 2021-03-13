using System;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfigurator<TJsonEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createPropertyContext"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        IContractResolverContext<TJsonEntity> Configure(IContractResolverContext<TJsonEntity> createPropertyContext, Func<IContractResolverContext<TJsonEntity>> next);
    }
}