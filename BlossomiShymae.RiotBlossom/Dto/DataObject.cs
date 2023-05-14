using BlossomiShymae.RiotBlossom.Core;

namespace BlossomiShymae.RiotBlossom.Dto
{
    public abstract record DataObject<T> where T : notnull
    {
        private T? _data;
        protected T Data
        {
            get => _data ?? throw new InvalidOperationException($"{nameof(Data)} property must be initialized for {typeof(T)}!");
            set => _data = value;
        }

        public DataObject() { }

        public override string ToString()
        {
            return PrettyPrinter.GetString(Data);
        }
    }
}
