namespace NebusokuDev.ShooterWeaponSystem.Runtime.Collision
{
    public interface IObjectPermission
    {
        bool SelfInteract { get; }
        bool SelfDamage { get; }
        bool SelfOwned { get; }

        bool TeamInteract { get; }
        bool TeamDamage { get; }
        bool TeamOwned { get; }

        bool EnemyInteract { get; }
        bool EnemyDamage { get; }
        bool EnemyOwned { get; }
    }
}