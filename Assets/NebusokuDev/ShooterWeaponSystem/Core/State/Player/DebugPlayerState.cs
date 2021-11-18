using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.State.Player
{
    public class DebugPlayerState : MonoBehaviour, IPlayerState
    {
        [SerializeField] private PlayerMovementContext context;
        public PlayerMovementContext Context => context;
    }
}