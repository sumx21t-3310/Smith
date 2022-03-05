using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input
{
    public class Sensitivity<T> : MonoBehaviour, ISensitivity<T> where T : ICameraInput
    {
        [SerializeField] private Vector2 value = Vector2.one * 5f;

        public Vector2 Value
        {
            get => value;
            set => this.value = new Vector2(Mathf.Abs(value.x), Mathf.Abs(value.y));
        }
    }
}