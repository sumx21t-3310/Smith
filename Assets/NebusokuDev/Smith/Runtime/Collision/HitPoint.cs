using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace NebusokuDev.Smith.Runtime.Collision
{
    public class HitPoint : MonoBehaviour, IHasHitPoint
    {
        [SerializeField] private float maxHp;
        [ReadOnly, SerializeField] private float currentHp;

        public UnityEvent<float, float> onTakeDamage;
        public UnityEvent onDie;
        private bool _isDeed;

        private void OnEnable()
        {
            _isDeed = false;
            currentHp = maxHp;
        }

        public void AddDamage(float damage)
        {
            if (damage >= currentHp && _isDeed == false)
            {
                Death();
                currentHp = 0f;
                return;
            }

            currentHp -= damage;
            onTakeDamage.Invoke(damage, currentHp);
        }

        public void AddRecovery(float hitPoint) => currentHp = Mathf.Clamp(currentHp + hitPoint, 0f, maxHp);

        public void Death()
        {
            _isDeed = true;
            onDie.Invoke();
        }
    }
}