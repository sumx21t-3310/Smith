namespace NebusokuDev.Smith.Runtime.Collision
{
    public interface IHitBox
    {
        BodyType BodyType { get; }
        IObjectGroup ObjectGroup { get; }
        void AddDamage(float damage);
    }
}