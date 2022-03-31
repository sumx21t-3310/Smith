using System;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.Sensor
{
    [Serializable]
    public class RayCastSensor : IGroundSensor
    {
        [SerializeField] private LayerMask groundLayer = -1;
        [SerializeField] private float groundDistance = .2f;


        public bool IsGrounded(CharacterController controller)
        {
            var offset = new Vector3(0f, controller.height / 2f - controller.radius);
            var transform = controller.transform;
            var ray = new Ray(transform.TransformPoint(controller.center) - offset, Vector3.down);

            if (Physics.Raycast(ray, out var hit, groundLayer))
            {
                var distance = hit.distance;
                UnityEngine.Debug.Log(distance < controller.radius + groundDistance);
                return distance < controller.radius + groundDistance;
            }


            return false;
        }

        public Vector3 Normal(CharacterController controller, Vector3 direction)
        {
            var transform = controller.transform;
            var ray = new Ray(transform.position + direction.normalized * controller.radius, Vector3.down);

            if (Physics.Raycast(ray, out var hit, groundLayer))
            {
                return hit.normal;
            }


            return Vector3.zero;
        }


        private float GetOriginHeight(CharacterController controller) => controller.height / 2f - controller.radius;
    }
}