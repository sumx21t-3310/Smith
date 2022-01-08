using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool
{
    public interface IObjectPoolFactory
    {
        IObjectPool<T> CreatePool<T>(T prefab, int preInstantiate) where T : Component;
    }
}