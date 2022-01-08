using NebusokuDev.Smith.Runtime.Dependency.ObjectPool.Default;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool
{
    public class ObjectPoolBinder : MonoBehaviour
    {
        [SerializeReference, SubclassSelector] private IObjectPoolFactory _factory = new DefaultObjectPoolFactory();

        private void Awake() => Locator<IObjectPoolFactory>.Instance.Bind(_factory);
    }
}