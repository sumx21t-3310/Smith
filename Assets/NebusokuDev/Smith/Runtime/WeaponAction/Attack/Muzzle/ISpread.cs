using NebusokuDev.Smith.Runtime.State.Player;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    public interface ISpread
    {
        public PlayerMovementContext Context { get; }


        public Vector3 Defuse(bool isAim, float t);
    }
}