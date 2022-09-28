using NebusokuDev.Smith.Runtime.Collision;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.DamageValidation
{
    public class StandardObjectValidator : IDamageValidator
    {
        public bool CanAddDamage(IObjectIdentity owner, IObjectIdentity target, IObjectPermission permission)
        {
            if (owner.SelfId == target.SelfId && permission.SelfDamage)
            {
                return true;
            }

            if (owner.TeamId == target.TeamId && permission.TeamDamage)
            {
                return true;
            }
            

            return owner.TeamId != target.TeamId && permission.EnemyDamage;
        }
    }
}