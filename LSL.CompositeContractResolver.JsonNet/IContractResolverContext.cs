namespace LSL.CompositeContractResolver.JsonNet
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TJsonEntity"></typeparam>
    public interface IContractResolverContext<TJsonEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        TJsonEntity ReturnValue { get; }
    }
}