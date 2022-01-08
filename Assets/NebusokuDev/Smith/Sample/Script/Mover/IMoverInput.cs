using UnityEngine;

namespace NebusokuDev.Smith.Sample.Script.Mover
{
    public interface IMoverInput
    {
        Vector3 Direction { get; }
        
        float Horizontal { get; }
        float Vertical { get; }
        
        bool IsSprint { get; }
        
        bool IsJump { get; }
        bool IsCrouch { get; }
    }
}