using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement
{
    public static class CharacterControllerHelper
    {
        public static Vector3 BottomPoint(this CharacterController controller)
        {
            var center2World = controller.transform.TransformPoint(controller.center);
            var bottom = new Vector3(0f, controller.height / 2f);
            return center2World - bottom;
        }

        public static Vector3 TopPoint(this CharacterController controller)
        {
            var center2World = controller.transform.TransformPoint(controller.center);
            var top = new Vector3(0f, controller.height / 2f);
            return center2World + top;
        }

        public static Vector3 Friction(Vector3 velocity, float friction) =>
            velocity - velocity * Time.deltaTime * friction;

        public static Vector3 Accelerate(Vector3 moveVelocity, Vector3 direction, float f, float groundAccel1)
        {
            return moveVelocity;
        }

        public static Vector3 Jump(Vector3 direction, float height, float gravity)
        {
            return direction * Mathf.Sqrt(-2f * height * gravity);
        }
    }
}