using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Attack.Muzzle
{
    [CreateAssetMenu(menuName = "WeaponSystem/SpreadProfile")]
    public class SpreadProfile : SpreadSettingBase
    {
        [SerializeField] private Spread[] spreads;

        public override Spread this[PlayerMovementContext context]
        {
            get
            {
                foreach (var spread in spreads)
                {
                    if (spread.Context == context) return spread;
                }

                return Spread.Default;
            }
        }
    }
}