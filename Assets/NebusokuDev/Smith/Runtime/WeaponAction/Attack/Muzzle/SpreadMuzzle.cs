using System;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;
using static UnityEngine.Quaternion;


namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    [Serializable, AddTypeMenu("Spread")]
    public class SpreadMuzzle : IdentityMuzzle
    {
        [SerializeField] private SpreadProfile spreadProfile;
        [SerializeField] private int maxShotCount = 15;


        public override void Defuse(IPlayerState playerState, IWeaponContext weaponContext)
        {
            var camera = Locator<IReferenceCamera>.Instance.Current.Center;
            var spread = spreadProfile[playerState.Context];

            var defuse = camera.rotation * spread.Defuse(weaponContext.IsAim, (float)weaponContext.ShotCount / maxShotCount)
                         + camera.forward;
            reference.rotation = LookRotation(defuse);
        }
    }
}