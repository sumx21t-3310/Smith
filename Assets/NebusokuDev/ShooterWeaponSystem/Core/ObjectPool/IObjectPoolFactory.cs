using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.ObjectPool
{
    public interface IObjectPoolFactory
    {
        IObjectPool<T> CreatePool<T>(T prefab, int preInstantiate) where T : Component;
    }
}