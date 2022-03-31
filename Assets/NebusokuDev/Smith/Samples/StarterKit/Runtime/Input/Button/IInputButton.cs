namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Input.Button
{
    public interface IInputButton
    {
        bool IsPressDown { get; }

        bool IsPressUp { get; }

        bool IsPressed { get; }
    }
}