using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.State.Player
{
    public class DebugPlayerState : MonoBehaviour, IPlayerState
    {
        [SerializeField] private PlayerMovementContext context;
        public PlayerMovementContext Context => context;
    }
}