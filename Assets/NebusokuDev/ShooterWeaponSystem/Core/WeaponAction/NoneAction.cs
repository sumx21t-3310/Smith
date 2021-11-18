using System;
using NebusokuDev.ShooterWeaponSystem.Core.Magazine;
using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction
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