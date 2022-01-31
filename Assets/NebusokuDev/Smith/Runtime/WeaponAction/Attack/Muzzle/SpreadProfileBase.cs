using NebusokuDev.Smith.Runtime.State.Player;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    public abstract class SpreadSettingBase : ScriptableObject
    {
        public abstract Spread this[PlayerMovementContext context] { get; }
    }
}