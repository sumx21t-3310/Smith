using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool
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