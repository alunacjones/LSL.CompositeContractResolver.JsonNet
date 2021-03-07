using System.Collections.Generic;

namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfigurator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        IEnumerable<IConfigurator> ScopedConfigurators { get; }
    }
}