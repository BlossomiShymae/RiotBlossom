using BlossomiShymae.RiotBlossom.Core.Utils;

namespace BlossomiShymae.RiotBlossom.Data.Dtos
{
    public abstract record DataObject
    {
        public sealed override string ToString()
        {
            return PrettyPrinter.GetString(this, GetType().Name);
        }
    }
}
