using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Interact
{
    public class GrabItem : MonoBehaviour, ICanGrab
    {
        [SerializeField] private bool cameraLookAt;
        private Transform _self;


        private void Start() => _self = transform;


        public void Grab(Vector3 position, Vector3 forward)
        {
            _self.position = position;

            if (cameraLookAt) _self.forward = forward;
        }
    }
}