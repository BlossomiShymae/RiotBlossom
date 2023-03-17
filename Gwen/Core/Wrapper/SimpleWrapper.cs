namespace Gwen.Core.Wrapper
{
    /// <summary>
    /// A wrapper client used for single platform use.
    /// </summary>
    public interface ISimpleWrapper
    {
        /// <summary>
        /// The component used to access Riot Games APIs. Locked to given <see cref="Type.PlatformRoute"/>.
        /// </summary>
        IRiotCore Riot { get; }
    }

    internal class SimpleWrapper : ISimpleWrapper
    {
        private readonly RiotCore _riotCore;
        /// <inheritdoc/>
        public IRiotCore Riot { get { return _riotCore; } }

        public SimpleWrapper(RiotCore riotCore)
        {
            _riotCore = riotCore;
        }
    }
}
