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
        TJsonEntity Configure(IContractResolverContext<TJsonEntity> createPropertyContext, Func<TJsonEntity> next);
    }
}