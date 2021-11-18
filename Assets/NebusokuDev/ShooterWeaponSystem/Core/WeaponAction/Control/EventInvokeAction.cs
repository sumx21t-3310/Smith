using System;
using NebusokuDev.ShooterWeaponSystem.Core.Magazine;
using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using UnityEngine;
using UnityEngine.Events;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Control
{
    [Serializable, AddTypeMenu("Control/EventEventInvoke")]
    public class EventInvokeAction : IWeaponAction
    {
        public UnityEvent<bool> onAction;
        public UnityEvent<bool> onAltAction;
        public UnityEvent onHolster;
        public UnityEvent onDraw;

        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext) { }

        public void Action(bool isAction, IPlayerState playerState) => onAction.Invoke(isAction);

        public void AltAction(bool isAltAction, IPlayerState playerState) => onAltAction.Invoke(isAltAction);

        public void OnHolster() => onHolster.Invoke();


        public void OnDraw() => onDraw.Invoke();
    }
}