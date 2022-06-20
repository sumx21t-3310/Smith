namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.Input
{
    public interface IMoverInput
    {
        float Vertical { get; }
        float Horizontal { get; }
        bool IsJump { get; }

        bool IsCrouch { get; }

        bool IsSprint { get; }
    }
}