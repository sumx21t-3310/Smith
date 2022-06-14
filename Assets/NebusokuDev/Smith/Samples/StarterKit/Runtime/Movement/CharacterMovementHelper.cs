using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement
{
    public static class CharacterControllerExtension
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
    }
}