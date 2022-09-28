using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool
{
    public abstract class ObjectPoolBinderBase : MonoBehaviour
    {
        protected void Awake() => Locator<IObjectPoolFactory>.Instance.Bind(BindObjectPoolFactory());
        protected abstract IObjectPoolFactory BindObjectPoolFactory();
    }
}