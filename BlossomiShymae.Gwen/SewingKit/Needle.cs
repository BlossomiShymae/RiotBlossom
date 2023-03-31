namespace BlossomiShymae.Gwen.SewingKit
{
    public class Needle<T> where T : notnull
    {
        private readonly T _data;

        private Needle(T data)
        {
            _data = data;
        }

        public static Needle<T> From(T data)
        {
            return new Needle<T>(data);
        }

        public async Task<Needle<U>> Bind<U>(Func<T, Task<U>> func) where U : notnull
        {
            return new Needle<U>(await func(_data));
        }

        public T Work()
        {
            return _data;
        }
    }

    public static class NeedleExtensions
    {
        public static async Task<Needle<U>> Bind<T, U>(this Task<Needle<T>> task, Func<T, Task<U>> func)
            where T : notnull
            where U : notnull
        {
            return await (await task).Bind(func);
        }

        public static async Task<T> WorkAsync<T>(this Task<Needle<T>> task) where T : notnull
        {
            return (await task).Work();
        }
    }
}
