namespace NebusokuDev.Smith.Runtime.Collision
{
    public interface IHitBox
    {
        HitType HitType { get; }
        IObjectIdentity ObjectIdentity { get; }
        void AddDamage(float damage);
    }
}