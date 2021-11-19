using System;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.State.Player
{
    [Serializable]
    public class RestPlayerState : IPlayerState
    {
        public PlayerMovementContext Context => PlayerMovementContext.Rest;
    }
}
