using System;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle.Spread;
using UnityEngine;


namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    [Serializable, AddTypeMenu("Spread")]
    public class SpreadMuzzle : IdentityMuzzle
    {
        [SerializeField] private SpreadProfileBase spreadProfile;
        [SerializeField] private int maxShotCount = 15;

        public override Vector3 Direction => shotPoint.forward + DefuseOffset;

        protected Vector3 DefuseOffset;


        public override void Defuse(IPlayerState playerState, IWeaponContext weaponContext)
        {
            base.Defuse(playerState, weaponContext);
            var camera = Locator<IReferenceCamera>.Instance.Current;
            var spread = spreadProfile[playerState.Context];


            DefuseOffset = camera.Rotation *
                         spread.Defuse(weaponContext.IsAim, (float) weaponContext.ShotCount / maxShotCount);
        }
    }
}