using System;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle.Spread;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    [Serializable, AddTypeMenu("ViewPortSpread")]
    public class ViewPortSpreadMuzzle : ViewPortIdentityMuzzle
    {
        [SerializeField] private SpreadProfileBase spreadProfile;
        [SerializeField] private int maxShotCount = 15;
        protected Vector3 SpreadOffset;

        public override Vector3 Direction => SavedDirection + SavedRotation * SpreadOffset;

        public override void Defuse(IPlayerState playerState, IWeaponContext weaponContext)
        {
            base.Defuse(playerState, weaponContext);

            var spread = spreadProfile[playerState.Context];
            SpreadOffset = spread.Defuse(weaponContext.IsAim, (float) weaponContext.ShotCount / maxShotCount);
        }
    }
}