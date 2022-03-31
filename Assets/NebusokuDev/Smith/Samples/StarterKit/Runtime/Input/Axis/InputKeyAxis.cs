using System;
using NebusokuDev.Smith.Samples.StarterKit.Runtime.Input.Button;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Input.Axis
{
    [Serializable]
    public class InputKeyAxis : IInputAxis
    {
        [SerializeField] private InputKeyButton positiveKeyButton;
        [SerializeField] private InputKeyButton negativeKeyButton;
        private float _value;

        public InputKeyAxis(InputKeyButton positiveKeyButton, InputKeyButton negativeKeyButton)
        {
            this.positiveKeyButton = positiveKeyButton;
            this.negativeKeyButton = negativeKeyButton;
        }


        public float GetAxis()
        {
            if (positiveKeyButton.IsPressed) return 1f;

            if (negativeKeyButton.IsPressed) return -1f;

            _value -= _value * Time.deltaTime;
            return _value;
        }


        public float GetRawAxis()
        {
            if (positiveKeyButton.IsPressed) return 1f;

            if (negativeKeyButton.IsPressed) return -1f;

            return 0f;
        }
    }
}