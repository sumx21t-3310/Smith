using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Sample.Script.Mover
{
    public interface IMoverInput
    {
        Vector3 Direction { get; }
        
        float Horizontal { get; }
        float Vertical { get; }
        
        bool IsJump { get; }
        bool IsCrouch { get; }
    }
}