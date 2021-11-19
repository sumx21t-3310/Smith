using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.ObjectPool.Deactivate
{
    public class RigidbodySleepDeactivate : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        private void Awake() => _rigidbody = GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            if (_rigidbody.IsSleeping() == false) return;
            gameObject.SetActive(false);
        }
    }
}