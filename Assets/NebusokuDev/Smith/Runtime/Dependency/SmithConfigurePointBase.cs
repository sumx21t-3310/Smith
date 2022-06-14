using NebusokuDev.Smith.Runtime.Dependency.ObjectPool;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency
{
    public abstract class SmithConfigurePointBase : MonoBehaviour
    {
        private void Awake()
        {
            Locator<IObjectPoolFactory>.Instance.Bind(ConfigureObjectPoolFactory());
        }

        protected abstract IObjectPoolFactory ConfigureObjectPoolFactory();
    }
}