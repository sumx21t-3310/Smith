using System;
using NebusokuDev.ShooterWeaponSystem.Core.Magazine;
using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction
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
            UnityEngine.Debug.Log(message);
        #endif
        }
    }
}