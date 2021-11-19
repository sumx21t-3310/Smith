using System;
using NebusokuDev.ShooterWeaponSystem.Runtime.Magazine;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Player;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction
{
    [Serializable, AddTypeMenu("None")]
    public class NoneAction : IWeaponAction
    {
        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext) { }


        public void Action(bool isAction, IPlayerState playerState) { }

        public void AltAction(bool isAltAction, IPlayerState playerState) { }

        public void OnHolster() { }


        public void OnDraw() { }
    }
}