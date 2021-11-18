using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.ObjectPool
{
    public interface IObjectPool<out TComponent> where TComponent : Component
    {
        TComponent GetObject();
        int PlayingCount { get; }
        int MaxPooling { get; set; }
        void Sleep();
        void Clear();
    }
}