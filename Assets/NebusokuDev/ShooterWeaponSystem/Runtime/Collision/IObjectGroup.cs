using System;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Collision
{
    public interface IObjectGroup
    {
        Guid SelfId { get; }
        int GroupId { get; }
    }
}