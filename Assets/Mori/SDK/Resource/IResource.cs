using System;

namespace Mori.SDK.Resource
{
    public interface IResource<T>
    {
        public event Action<T, T> Changed;

        public ResourceType Type { get; }
        public T Amount { get; }
    }
}