using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.ObjectPool
{
    public interface IObjectPoolFactory
    {
        IObjectPool<T> CreatePool<T>(T prefab, int preInstantiate) where T : Component;
    }
}