using System;
using NebusokuDev.Smith.Runtime.Domain.Magazine;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction
{
    [Serializable, AddTypeMenu("Debug")]
    public class DebugAction : IWeaponAction
    {
        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext) => Log(parent.name);

        public void Action(bool isAction, IPlayerState playerState) => Log($"isAction: {isAction.ToString()}");


        public void AltAction(bool isAltAction, IPlayerState playerState) =>
                Log($"isAltAction: {isAltAction.ToString()}");


        public void OnHolster() => Log("OnHolster");


        public void OnDraw() => Log("OnDraw");


        private void Log(string message)
        {
        #if DEBUG || UNITY_EDITOR
            Debug.Log(message);
        #endif
        }
    }
}