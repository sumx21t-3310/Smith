using System;
using NebusokuDev.Smith.Runtime.Input.Legacy.Button;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input.Legacy
{
    [Serializable]
    public class MouseWheelButton : IInputButton
    {
        public bool IsPressDown => Mathf.Abs(UnityEngine.Input.mouseScrollDelta.x) < 0.1f;
        public bool IsPressUp => Mathf.Abs(UnityEngine.Input.mouseScrollDelta.x) > 0f;
        public bool IsPressed => Mathf.Abs(UnityEngine.Input.mouseScrollDelta.x) > 0f;
    }
}