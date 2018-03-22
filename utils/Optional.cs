using System;

namespace Utils 
{
    public struct Option<T> 
    {
        private readonly bool hasValue;
        private readonly T value;
        
        internal Option(T value, Boolean hasValue)
        {
            this.value = value;
            this.hasValue = hasValue;
        }

        public TOut Match<TOut>(Func<T, TOut> some, Func<TOut> none)
        {
            return this.hasValue ?
                some(this.value) :
                none();
        }
    }

    public static class Option
    {    
        public static Option<T> ToOption<T>(this T value)
        {
            return ToOption<T>(value, _ => Equals(_, default(T)));
        }

        public static Option<T> ToOption<T>(this T value, Predicate<T> noneWhen)
        {
            return noneWhen(value) ? None<T>() : Some(value);
        }
        
        public static Option<T> Some<T>(T value)
        {
            return new Option<T>(value, true);
        }

        public static Option<T> None<T>()
        {
            return new Option<T>(default(T), false);
        }
    }    
}