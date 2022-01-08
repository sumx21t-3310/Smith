using System;

namespace NebusokuDev.Smith.Runtime.State.Player
{
    [Serializable]
    public class RestPlayerState : IPlayerState
    {
        public PlayerMovementContext Context => PlayerMovementContext.Rest;
    }
}
