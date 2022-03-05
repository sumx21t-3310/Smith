using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input
{
    public class SensitivityBase<T> : MonoBehaviour, ISensibility<T> where T : ICameraInput
    {
        public Vector2 Value
        {
            get => _value;
            set => _value = new Vector2(Mathf.Abs(value.x), Mathf.Abs(value.y));
        }

        private Vector2 _value;
    }
}