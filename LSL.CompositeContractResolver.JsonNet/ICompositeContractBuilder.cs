using System;
using System.Collections.Generic;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICompositeContractBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        CompositeContractResolver Build(Action<ICompositeContractResolverContext> configurator);
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ICompositeContractResolverContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyConfigurators"></param>
        /// <returns></returns>
        ICompositeContractResolverContext WithPropertyCongigurators(IEnumerable<IPropertyConfigurator> propertyConfigurators)
    }
}