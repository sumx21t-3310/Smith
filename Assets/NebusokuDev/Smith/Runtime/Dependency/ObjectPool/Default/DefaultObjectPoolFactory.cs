using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool.Default
{
    [AddTypeMenu("Default"), Serializable]
    public class DefaultObjectPoolFactory : IObjectPoolFactory
    {
        public IObjectPool<T> CreatePool<T>(T prefab, int preInstantiate) where T : Component
        {
            return new DefaultObjectPool<T>(prefab, preInstantiate);
        }
    }
}