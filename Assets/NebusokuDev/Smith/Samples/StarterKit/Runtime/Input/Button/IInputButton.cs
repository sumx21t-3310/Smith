namespace NebusokuDev.Smith.Samples.StarterKit.Input.Legacy.Button
{
    public interface IInputButton
    {
        bool IsPressDown { get; }

        bool IsPressUp { get; }

        bool IsPressed { get; }
    }
}