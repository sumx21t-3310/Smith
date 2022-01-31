using NebusokuDev.Smith.Runtime.State.Player;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    public abstract class SpreadProfileBase : ScriptableObject
    {
        public abstract ISpread this[PlayerMovementContext context] { get; }
    }
}