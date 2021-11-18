using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.ObjectPool.Deactivate
{
    public class CollisionDeactivate : MonoBehaviour
    {
        [SerializeField] private int maxHitCount = 1;
        private int _hitCount;
        private void OnEnable() => _hitCount = 0;
        private void OnCollisionEnter(UnityEngine.Collision _)
        {
            _hitCount++;
            if (_hitCount < maxHitCount) return;
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider _)
        {
            _hitCount++;
            if (_hitCount < maxHitCount) return;
            gameObject.SetActive(false);
        }
    }
}