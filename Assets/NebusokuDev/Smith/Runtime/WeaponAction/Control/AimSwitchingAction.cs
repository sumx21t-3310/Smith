using System;
using NebusokuDev.Smith.Runtime.Domain.Magazine;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Control
{
    /// <summary>
    /// Aim時に挙動を変えることができるアクション
    /// Valorantのヴァンダルのような動作を実現するためのクラス
    /// </summary>
    [Serializable, AddTypeMenu("Control/AimSwitching")]
    public class AimSwitchingAction : IWeaponAction
    {
        [SerializeReference, SubclassSelector] private IWeaponAction _defaultAction = new NoneAction();
        [SerializeReference, SubclassSelector] private IWeaponAction _aimingAction = new NoneAction();

        private IWeaponContext _weaponContext;


        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext)
        {
            _defaultAction.Injection(parent, magazine, weaponContext);
            _aimingAction.Injection(parent, magazine, weaponContext);
            _weaponContext = weaponContext;
        }


        public void Action(bool isAction, IPlayerState playerState)
        {
            if (_weaponContext.IsAim)
            {
                _aimingAction.Action(isAction, playerState);

                return;
            }

            _defaultAction.Action(isAction, playerState);
        }


        public void AltAction(bool isAltAction, IPlayerState playerState) { }

        public void OnHolster() { }


        public void OnDraw() { }
    }
}