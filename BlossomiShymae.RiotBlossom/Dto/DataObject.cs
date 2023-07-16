using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto
{
    public abstract record DataObject
    {
        public sealed override string ToString()
        {
            return PrettyPrinter.GetString(this, GetType().Name);
        }
    }
}
