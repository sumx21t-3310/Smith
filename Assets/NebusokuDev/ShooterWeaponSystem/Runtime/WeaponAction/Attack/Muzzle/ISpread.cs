using NebusokuDev.ShooterWeaponSystem.Runtime.State.Player;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.Muzzle
{
    public interface ISpread
    {
        public PlayerMovementContext Context { get; }


        public Vector3 Defuse(bool isAim, float t);
    }
}