namespace NebusokuDev.Smith.Runtime.Input.Legacy.Button
{
    public interface IInputButton
    {
        bool IsPressDown { get; }

        bool IsPressUp { get; }

        bool IsPressed { get; }
    }
}