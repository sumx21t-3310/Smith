using NebusokuDev.Smith.Runtime.Collision;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.DamageValidation
{
    public interface IDamageValidator
    {
        bool CanAddDamage(IObjectIdentity owner, IObjectIdentity target, IObjectPermission permission);
    }
}