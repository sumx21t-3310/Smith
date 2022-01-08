using System;

namespace NebusokuDev.Smith.Runtime.Dependency
{
    public sealed class Locator<T> where T : class
    {
        public static Locator<T> Instance => _instance.Value;
        private static Lazy<Locator<T>> _instance = new Lazy<Locator<T>>(() => new Locator<T>());

        private Locator() { }

        public T Current { get; private set; }

        public bool IsValid => Current != null;

        public void Bind(T item) => Current = item;

        public void Unbind(T item)
        {
            if (IsValid == false) return;
            Current = Current == item ? null : Current;
        }
    }
}