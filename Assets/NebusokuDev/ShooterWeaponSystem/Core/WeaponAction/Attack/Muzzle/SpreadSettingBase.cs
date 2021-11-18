using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Attack.Muzzle
{
    public abstract class SpreadSettingBase : ScriptableObject
    {
        public abstract Spread this[PlayerMovementContext context] { get; }
    }
}