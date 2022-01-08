using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input.Legacy
{
    [Serializable]
    public class InputKeyAxis : IInputAxis
    {
        [SerializeField] private InputButtons positiveButtons;
        [SerializeField] private InputButtons negativeButtons;
        private float _value;

        public InputKeyAxis(InputButtons positiveButtons, InputButtons negativeButtons)
        {
            this.positiveButtons = positiveButtons;
            this.negativeButtons = negativeButtons;
        }


        public float GetAxis()
        {
            if (positiveButtons.IsPressed) return 1f;

            if (negativeButtons.IsPressed) return -1f;

            _value -= _value * Time.deltaTime;
            return _value;
        }


        public float GetRawAxis()
        {
            if (positiveButtons.IsPressed) return 1f;

            if (negativeButtons.IsPressed) return -1f;

            return 0f;
        }
    }
}