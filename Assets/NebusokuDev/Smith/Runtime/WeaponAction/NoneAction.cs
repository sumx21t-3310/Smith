using System;
using NebusokuDev.Smith.Runtime.Domain.Magazine;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction
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