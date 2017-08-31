namespace ResumeApi.Common.Extensions
{
    using System;

    public static class Disposable
    {
        public static U Using<T, U>(Func<T> creator, Func<T, U> mapper) where T : IDisposable
        {
            if (creator == null)
                throw new ArgumentNullException(nameof(creator));

            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            using (var obj = creator())
            {
                return mapper(obj);
            }
        }

        public static void Using<T>(Func<T> creator, Action<T> action) where T : IDisposable
        {
            if (creator == null)
                throw new ArgumentNullException(nameof(creator));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            using (var obj = creator())
            {
                action(obj);
            }
        }
    }
}
