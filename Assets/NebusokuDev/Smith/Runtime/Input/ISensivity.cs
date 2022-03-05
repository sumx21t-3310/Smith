using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input
{
    public interface ISensibility<T> where T : ICameraInput
    {
        Vector2 Value { get; }
    }
}