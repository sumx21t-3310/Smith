using NebusokuDev.Smith.Runtime.Extension;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool.Default
{
    public class RigidbodySleepDeactivator : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            if (_rigidbody.IsSleeping() == false) return;
            gameObject.LightSetActive(false);
        }
    }
}