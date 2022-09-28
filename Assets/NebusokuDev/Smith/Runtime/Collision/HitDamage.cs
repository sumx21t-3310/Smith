using System;

namespace NebusokuDev.Smith.Runtime.Collision
{
    [Serializable]
    public struct HitDamage
    {
        public static HitDamage None => new HitDamage(HitType.Object);

        public HitType hitType;
        public float damage;

        public HitDamage(HitType hitType, float damage = 0f)
        {
            this.damage = damage;
            this.hitType = hitType;
        }
    }
}