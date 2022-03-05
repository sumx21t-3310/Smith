using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input
{
    public interface ISensitivity<T> where T : ICameraInput
    {
        Vector2 Value { get; }
    }
}