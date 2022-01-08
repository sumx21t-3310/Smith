using System;

namespace NebusokuDev.Smith.Runtime.Collision
{
    public interface IObjectGroup
    {
        Guid SelfId { get; }
        int GroupId { get; }
    }
}