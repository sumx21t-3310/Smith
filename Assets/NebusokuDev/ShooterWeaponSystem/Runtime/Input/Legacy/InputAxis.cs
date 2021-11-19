using System;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Input.Legacy
{
    [Serializable]
    public class InputAxis
    {
        [SerializeField] private string[] axes;
        [SerializeField] private float deadZone = .01f;


        public InputAxis(params string[] axis) => this.axes = axis;

        public InputAxis(float deadZone) : this() => this.deadZone = deadZone;


        public float GetAnyAxis()
        {
            foreach (var axis in axes)
            {
                var value = UnityEngine.Input.GetAxis(axis);

                if (Mathf.Abs(value) > deadZone) return value;
            }

            return 0f;
        }


        public float GetAnyRawAxis()
        {
            foreach (var axis in axes)
            {
                var value = UnityEngine.Input.GetAxisRaw(axis);

                if (Mathf.Abs(value) > deadZone) return value;
            }

            return 0f;
        }
    }
}