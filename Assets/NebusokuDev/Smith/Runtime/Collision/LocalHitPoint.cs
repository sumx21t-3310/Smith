using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace NebusokuDev.Smith.Runtime.Collision
{
    public class LocalHitPoint : MonoBehaviour, IHasHitPoint
    {
        [SerializeField] private float maxHp = 200f;
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
            currentHp -= damage;

            if (damage >= currentHp && _isDeed == false)
            {
                Death();
                currentHp = 0f;
                return;
            }

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