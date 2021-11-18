namespace NebusokuDev.ShooterWeaponSystem.Core.Collision
{
    public interface IHasHitPoint
    {
        void AddDamage(float damage);
        void AddRecovery(float hitPoint);
        void Death();
    }
}