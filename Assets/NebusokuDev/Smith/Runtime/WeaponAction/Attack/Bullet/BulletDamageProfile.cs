using NebusokuDev.Smith.Runtime.Collision;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet
{
    [CreateAssetMenu(menuName = "WeaponSystem/BulletDamageProfile")]
    public class BulletDamageProfile : ScriptableObject
    {
        [SerializeField] private float maxDistance = 300f;
        [SerializeField] private AnimationCurve damageDecayCurve = AnimationCurve.Linear(0f, 1f, 1f, .85f);
        [SerializeField] private HitDamage[] damages;

        public float MaxDistance => maxDistance;

        public float GetDamage(BodyType bodyType, float distance = 0f)
        {
            foreach (var damage in damages)
            {
                if (bodyType == damage.bodyType) return damage.damage * GetImpact(distance);
            }

            return 0f;
        }

        public float GetImpact(float distance) => damageDecayCurve
            .Evaluate(Mathf.Clamp(distance, 0f, maxDistance) / maxDistance);
    }
}