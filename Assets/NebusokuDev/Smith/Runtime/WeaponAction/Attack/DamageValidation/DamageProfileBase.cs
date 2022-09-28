using NebusokuDev.Smith.Runtime.Collision;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.DamageValidation
{
    public abstract class DamageProfileBase : ScriptableObject
    {
        public abstract float MaxDistance { get; }

        public abstract float GetDamage(HitType hitType, float distance = 0f);
    }
}