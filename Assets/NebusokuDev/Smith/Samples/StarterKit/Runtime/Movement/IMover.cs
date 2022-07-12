using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement
{
    public interface IMover
    {
        Vector3 Velocity { get; }
        bool IsGrounded { get; }
    }
}