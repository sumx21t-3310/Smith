using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input
{
    public interface ISensivity<T> where T : ICameraInput
    {
        Vector2 Value { get; }
    }
}