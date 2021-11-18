using System;


namespace NebusokuDev.ShooterWeaponSystem.Core.Collision
{
    [Serializable]
    public struct HitDamage
    {
        public static HitDamage None => new HitDamage(BodyType.Object);

        public BodyType bodyType;
        public float damage;

        public HitDamage(BodyType bodyType, float damage = 0f)
        {
            this.damage = damage;
            this.bodyType = bodyType;
        }
    }
}