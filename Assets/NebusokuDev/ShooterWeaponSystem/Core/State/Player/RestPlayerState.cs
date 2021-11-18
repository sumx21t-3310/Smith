using System;


namespace NebusokuDev.ShooterWeaponSystem.Core.State.Player
{
    [Serializable]
    public class RestPlayerState : IPlayerState
    {
        public PlayerMovementContext Context => PlayerMovementContext.Rest;
    }
}
