namespace NebusokuDev.ShooterWeaponSystem.Runtime.Camera
{
    public interface ICameraFixedStar
    {
        float VerticalInput { get; set; }
        float VerticalOffset { get; set; }
        float HorizontalInput { get; set; }
        float HorizontalOffset { get; set; }
    }
}