using System;
using NebusokuDev.Smith.Runtime.Magazine;
using NebusokuDev.Smith.Runtime.Sequence.Timer;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Template
{
    [Serializable]
    public abstract class IntervalActionBase : IWeaponAction
    {
        [SerializeReference, SubclassSelector] private IRpmTimer _rpm = new FixedRpmTimer();

        public abstract void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext);


        public void Action(bool isAction, IPlayerState playerState)
        {
            _rpm.Update();

            if (_rpm.IsOverTime == false) return;

            if (ValidateEmitAction(isAction, playerState) == false)
            {
                _rpm.Reset();
                OnCancelAction(playerState);

                return;
            }

            _rpm.Lap();
            OnAction(playerState);
        }


        protected abstract bool ValidateEmitAction(bool isAction, IPlayerState playerState);


        protected abstract void OnCancelAction(IPlayerState playerState);

        protected abstract void OnAction(IPlayerState playerState);

        protected abstract void OnEveryUpdate(IPlayerState playerState);

        public abstract void AltAction(bool isAltAction, IPlayerState playerState);


        public virtual void OnHolster() { }


        public virtual void OnDraw() { }
    }
}