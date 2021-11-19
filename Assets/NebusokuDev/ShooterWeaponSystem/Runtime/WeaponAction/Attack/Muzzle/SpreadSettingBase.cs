using NebusokuDev.ShooterWeaponSystem.Runtime.State.Player;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.Muzzle
{
    public abstract class SpreadSettingBase : ScriptableObject
    {
        public abstract Spread this[PlayerMovementContext context] { get; }
    }
}