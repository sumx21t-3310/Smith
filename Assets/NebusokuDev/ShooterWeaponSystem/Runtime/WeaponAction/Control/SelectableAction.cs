using System;
using NebusokuDev.ShooterWeaponSystem.Runtime.Magazine;
using NebusokuDev.ShooterWeaponSystem.Runtime.Sequence.FireMode;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Player;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon;
using UnityEngine;
using UnityEngine.Events;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Control
{
    [AddTypeMenu("Control/Selectable")]
    [Serializable]
    public class SelectableAction : IWeaponAction
    {
        [SerializeReference, SubclassSelector] private IWeaponAction[] _attackActionModes = {new NoneAction()};
        public UnityEvent onSelect;
        private SemiAuto _singleClick;
        private int _index;


        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext)
        {
            foreach (var attackActionMode in _attackActionModes)
            {
                attackActionMode.Injection(parent, magazine, weaponContext);
            }
        }


        public void Action(bool isAction, IPlayerState playerState) { _attackActionModes[_index].Action(isAction, playerState); }


        public void AltAction(bool isAltAction, IPlayerState playerState)
        {
            _singleClick ??= new SemiAuto();

            if (_singleClick.Evaluate(isAltAction) == false) return;
            _index = ++_index % _attackActionModes.Length;
            onSelect.Invoke();
        }


        public void OnHolster() { }


        public void OnDraw() { }
    }
}