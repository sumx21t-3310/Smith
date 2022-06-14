using System;
using NebusokuDev.Smith.Runtime.Collision;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet.DamageValidator
{
    public interface IDamageValidator
    {
        event Action OnSelfHit;
        event Action OnTeamHit;
        event Action OnEnemyHit;
        
        bool ValidateDamage(IObjectIdentity owner, IObjectIdentity target, IObjectPermission permission);
    }
}