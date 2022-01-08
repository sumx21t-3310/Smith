using UnityEngine;

namespace NebusokuDev.Smith.Runtime.State.Player
{
    public class DebugPlayerState : MonoBehaviour, IPlayerState
    {
        [SerializeField] private PlayerMovementContext context;
        public PlayerMovementContext Context => context;
    }
}