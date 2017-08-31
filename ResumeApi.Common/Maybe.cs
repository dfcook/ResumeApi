namespace ResumeApi.Common
{
    using System;    
    using System.Threading.Tasks;

    public static class Maybe
    {
        public static Maybe<T> ToMaybe<T>(this T value) where T : class
        {
            if (value == null)
                return None<T>();
            return Some(value);
        }

        public static Maybe<T> ToMaybe<T>(this T? value) where T : struct
        {
            if (!value.HasValue)
                return None<T>();
            return Some(value.Value);
        }

        public static Maybe<T> Some<T>(T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<T> None<T>()
        {
            return new Maybe<T>();
        }
    }

    public struct Maybe<T>
    {
        public static readonly Maybe<T> None = new Maybe<T>();

        private readonly bool _hasValue;
        private readonly T _value;

        internal Maybe(T value)
        {
            _value = value;
            _hasValue = true;
        }

        public T OrElse(Func<T> ifNone)
        {
            if (_hasValue)
                return _value;
            
            return ifNone();
        }

        public U Map<U>(Func<T, U> some = null, Func<U> none = null)
        {
            if (_hasValue)
            {
                if (some != null)
                {
                    return some(_value);
                }
            }

            if (none != null)
            {
                return none();
            }

            return default(U);
        }

        public void Do(Action<T> some = null, Action none = null)
        {
            if (_hasValue)
            {
                if (some != null)
                {
                    some.Invoke(_value);
                }
            }

            if (none != null)
            {
                none.Invoke();
            }
        }

        public Task<U> MatchAsync<U>(Func<T, Task<U>> some = null, Func<Task<U>> none = null)
        {
            if (_hasValue)
                if (some != null)
                    return some(_value);

            if (none != null)
                return none();

            return Task.FromResult(default(U));
        }
    }
}
