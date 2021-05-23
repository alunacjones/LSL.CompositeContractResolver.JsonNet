using System;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfigurator<TContext, TJsonEntity>
        where TContext : IContractResolverContext<TJsonEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createPropertyContext"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        TJsonEntity Configure(TContext createPropertyContext, Func<TJsonEntity> next);
    }
}