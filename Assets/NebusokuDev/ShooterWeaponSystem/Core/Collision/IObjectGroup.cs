using System;


namespace NebusokuDev.ShooterWeaponSystem.Core.Collision
{
    public interface IObjectGroup
    {
        Guid SelfId { get; }
        int GroupId { get; }
    }
}