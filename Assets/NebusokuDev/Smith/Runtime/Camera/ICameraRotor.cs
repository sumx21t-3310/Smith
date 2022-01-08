namespace NebusokuDev.Smith.Runtime.Camera
{
    public interface ICameraRotor
    {
        float VerticalInput { get; set; }
        float VerticalOffset { get; set; }
        float HorizontalInput { get; set; }
        float HorizontalOffset { get; set; }
    }
}