namespace Gwen.Core
{
	/// <summary>
	/// A stitch client used for single platform use.
	/// </summary>
	public interface ISimpleStitch
	{
		/// <summary>
		/// The component used to access Riot Games APIs. Locked to given <see cref="Type.PlatformRoute"/>.
		/// </summary>
		IRiotCore Riot { get; }
	}

	internal class SimpleStitch : ISimpleStitch
	{
		private readonly RiotCore _riotCore;
		/// <inheritdoc/>
		public IRiotCore Riot { get { return _riotCore; } }

		public SimpleStitch(RiotCore riotCore)
		{
			_riotCore = riotCore;
		}
	}
}
