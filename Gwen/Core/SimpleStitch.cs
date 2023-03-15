namespace Gwen.Core
{
	/// <summary>
	/// A stitch client used for single platform use.
	/// </summary>
	internal class SimpleStitch
	{
		private readonly RiotCore _riotCore;
		/// <summary>
		/// The component used to access Riot Games APIs. Locked to given <see cref="Type.PlatformRoute"/>.
		/// </summary>
		public RiotCore Riot { get { return _riotCore; } }

		public SimpleStitch(RiotCore riotCore)
		{
			_riotCore = riotCore;
		}
	}
}
