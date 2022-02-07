using NebusokuDev.Smith.Runtime.Dependency.ObjectPool;
using NebusokuDev.Smith.Runtime.Dependency.ObjectPool.Default;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.ProceduralAnimation
{
    public class CartridgeEjectionAnimation : MonoBehaviour, IProceduralAnimation
    {
        [SerializeField] private Rigidbody prefab;
        [SerializeField] private Transform ejectionPoint;
        [SerializeField] private Vector3 velocity;

        private IObjectPool<Rigidbody> _pool;


        public void Play()
        {
            _pool ??= new DefaultObjectPool<Rigidbody>(prefab);

            var clone = _pool.GetObject();
            clone.Sleep();
            clone.gameObject.SetActive(true);
            clone.position = ejectionPoint.position;
            clone.AddForce(ejectionPoint.rotation * velocity, ForceMode.VelocityChange);
        }
    }
}