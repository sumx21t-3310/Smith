using System;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.Input.Legacy
{
    [Serializable]
    public class InputKeyAxis
    {
        [SerializeField] private InputKeys positiveKeys;
        [SerializeField] private InputKeys negativeKeys;


        public InputKeyAxis(InputKeys positiveKeys, InputKeys negativeKeys)
        {
            this.positiveKeys = positiveKeys;
            this.negativeKeys = negativeKeys;
        }


        public float GetAxis()
        {
            if (positiveKeys.IsAnyKeyPressed) return 1f;

            if (negativeKeys.IsAnyKeyPressed) return -1f;

            return 0f;
        }
    }
}