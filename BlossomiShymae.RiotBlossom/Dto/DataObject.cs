using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto
{
    public abstract record DataObject<T>
    {
        internal static class Helper<U>
        {
            private static readonly string s_typeName = typeof(U).Name;
            public static string Name => s_typeName;
        }

        public sealed override string ToString()
        {
            return PrettyPrinter.GetString(this, Helper<T>.Name);
        }
    }
}
