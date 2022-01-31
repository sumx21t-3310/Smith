using System;
using NebusokuDev.Smith.Runtime.State.Player;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    [Serializable, AddTypeMenu("Non")]
    public class NonSpread : ISpread
    {
        public static readonly NonSpread Default = new NonSpread();

        [SerializeField] private PlayerMovementContext _context = PlayerMovementContext.Rest;

        public PlayerMovementContext Context => _context;

        public Vector3 Defuse(bool isAim, float t)
        {
            return Vector3.forward;
        }
    }
}