using System;
using NebusokuDev.Smith.Runtime.Magazine;
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
        [SerializeReference, SubclassSelector] private IWeaponAction _attackAction = new NoneAction();
        [SerializeReference, SubclassSelector] private IWeaponAction _aimingAttackAction = new NoneAction();

        private IWeaponContext _weaponContext;


        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext)
        {
            _attackAction.Injection(parent, magazine, weaponContext);
            _aimingAttackAction.Injection(parent, magazine, weaponContext);
            _weaponContext = weaponContext;
        }


        public void Action(bool isAction, IPlayerState playerState)
        {
            if (_weaponContext.IsAim)
            {
                _aimingAttackAction.Action(isAction, playerState);

                return;
            }

            _attackAction.Action(isAction, playerState);
        }


        public void AltAction(bool isAltAction, IPlayerState playerState) { }

        public void OnHolster() { }


        public void OnDraw() { }
    }
}