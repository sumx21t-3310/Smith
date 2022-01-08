using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool.Default
{
    public class CollisionDeactivator : MonoBehaviour
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