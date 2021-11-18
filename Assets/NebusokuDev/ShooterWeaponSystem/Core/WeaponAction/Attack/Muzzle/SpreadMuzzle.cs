using System;
using NebusokuDev.ShooterWeaponSystem.Core.Camera;
using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using UnityEngine;
using static UnityEngine.Quaternion;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Attack.Muzzle
{
    [Serializable, AddTypeMenu("Spread")]
    public class SpreadMuzzle : IdentityMuzzle
    {
        [SerializeField] private SpreadProfile spreadProfile;
        [SerializeField] private int maxShotCount = 15;


        public override void Defuse(IPlayerState playerState, IWeaponContext weaponContext)
        {
            var camera = Locator<ReferenceCameraBase>.Instance.Current.Center;
            var spread = spreadProfile[playerState.Context];

            var defuse = camera.rotation * spread.Defuse(weaponContext.IsAim, (float)weaponContext.ShotCount / maxShotCount)
                         + camera.forward;
            reference.rotation = LookRotation(defuse);
        }
    }
}