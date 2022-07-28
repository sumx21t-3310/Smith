namespace NebusokuDev.Smith.Runtime.Collision
{
    public interface IHitBox
    {
        BodyType BodyType { get; }
        IObjectIdentity ObjectIdentity { get; }
        void AddDamage(float damage);
    }
}