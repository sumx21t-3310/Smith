using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input.Legacy.Button
{
    [Serializable]
    public class MouseWheelButton : IInputButton
    {

        [SerializeField] private float threshold = Single.Epsilon;

        public bool IsPressDown => UnityEngine.Input.mouseScrollDelta.y > threshold;
        public bool IsPressUp => UnityEngine.Input.mouseScrollDelta.magnitude > threshold;
        public bool IsPressed => UnityEngine.Input.mouseScrollDelta.magnitude > threshold;
    }
}