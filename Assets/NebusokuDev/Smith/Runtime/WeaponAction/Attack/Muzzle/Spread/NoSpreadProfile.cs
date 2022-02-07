using NebusokuDev.Smith.Runtime.State.Player;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle.Spread
{
    [AddTypeMenu("Non")]
    public class NoSpreadProfile : SpreadProfileBase
    {
        public override ISpread this[PlayerMovementContext context] => NonSpread.Default;
    }
}