using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input.Legacy
{
    [Serializable]
    public class InputAxis : IInputAxis
    {
        [SerializeField] private string[] axes;
        [SerializeField] private float deadZone = .01f;


        public InputAxis(params string[] axis) => axes = axis;

        public InputAxis(float deadZone) : this() => this.deadZone = deadZone;


        public float GetAxis()
        {
            foreach (var axis in axes)
            {
                var value = UnityEngine.Input.GetAxis(axis);

                if (Mathf.Abs(value) > deadZone) return value;
            }

            return 0f;
        }


        public float GetRawAxis()
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