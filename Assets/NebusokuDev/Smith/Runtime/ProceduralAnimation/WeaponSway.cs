using NebusokuDev.Smith.Runtime.Input;
using UnityEngine;
using static UnityEngine.Quaternion;

namespace NebusokuDev.Smith.Runtime.ProceduralAnimation
{
    public class WeaponSway : MonoBehaviour
    {
        [SerializeField] private float dumpTime = .25f;
        [SerializeField] private Vector2 multiplier = Vector2.one;
        
        private ICameraInput _input;
        private Transform _self;

        private void Awake()
        {
            _self = transform;

            _input = GetComponent<ICameraInput>();
            if (_input == null)
            {
                _input = GetComponentInParent<ICameraInput>();
            }
        }

        private void Update()
        {
            var yawInput = Mathf.Clamp(_input.Horizontal * multiplier.x, -1f, 1f);
            var pitchInput = Mathf.Clamp(_input.Vertical * multiplier.y, -1f, 1f);

            var targetRotation = AngleAxis(yawInput, Vector3.up) * AngleAxis(pitchInput, Vector3.left);

            _self.localRotation = Slerp(_self.localRotation, targetRotation, Time.deltaTime / dumpTime);
        }
    }
}