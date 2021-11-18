using System;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.ObjectPool
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