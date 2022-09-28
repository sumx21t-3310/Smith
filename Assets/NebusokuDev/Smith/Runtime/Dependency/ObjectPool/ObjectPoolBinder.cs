using NebusokuDev.Smith.Runtime.Dependency.ObjectPool.Default;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool
{
    public class ObjectPoolBinder : ObjectPoolBinderBase
    {
        [SerializeReference, SubclassSelector] private IObjectPoolFactory _factory = new DefaultObjectPoolFactory();


        protected override IObjectPoolFactory BindObjectPoolFactory() => _factory;
    }
}