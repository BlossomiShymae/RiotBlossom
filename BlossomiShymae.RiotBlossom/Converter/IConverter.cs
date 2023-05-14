namespace BlossomiShymae.RiotBlossom.Converter
{
    internal interface IConverter<T, U>
    {
        T Convert(U value);
        U Convert(T value);
    }
}
