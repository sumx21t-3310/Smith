using NebusokuDev.Smith.Runtime.Collision;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.DamageValidation
{
    [CreateAssetMenu(menuName = "Smith/" + nameof(DamageProfile))]
    public class DamageProfile : DamageProfileBase
    {
        [SerializeField] private float maxDistance = 300f;
        [SerializeField] private AnimationCurve damageDecayCurve = AnimationCurve.Linear(0f, 1f, 1f, .85f);
        [SerializeField] private HitDamage[] damages;

        public override float MaxDistance => maxDistance;

        public override float GetDamage(HitType hitType, float distance = 0f)
        {
            foreach (var damage in damages)
            {
                if (hitType == damage.hitType) return damage.damage * GetImpact(distance);
            }

            return 0f;
        }

        public float GetImpact(float distance) => damageDecayCurve
            .Evaluate(Mathf.Clamp(distance, 0f, maxDistance) / maxDistance);
    }
}