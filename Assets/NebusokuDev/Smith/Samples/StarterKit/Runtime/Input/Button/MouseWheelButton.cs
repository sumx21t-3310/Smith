using System;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Input.Legacy.Button
{
    [Serializable]
    public class MouseWheelButton : IInputButton
    {
        public enum WheelDirection
        {
            Up,
            Down
        }

        [SerializeField] private WheelDirection wheelDirection = WheelDirection.Up;

        public bool IsPressDown => IsPressed;
        public bool IsPressUp => IsPressed;

        public bool IsPressed
        {
            get
            {
                switch (wheelDirection)
                {
                    case WheelDirection.Up:
                        return UnityEngine.Input.mouseScrollDelta.y > 0;

                    case WheelDirection.Down:
                        return UnityEngine.Input.mouseScrollDelta.y < 0;

                    default:
                        return false;
                }
            }
        }
    }
}