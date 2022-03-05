using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Extension
{
    public static class RigidbodyExtension
    {
        public static Rigidbody GetRigidbody(this GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out Rigidbody rigidbody))
            {
                return rigidbody;
            }

            return gameObject.AddComponent<Rigidbody>();
        }

        public static Rigidbody GetRigidbody(this GameObject gameObject, Action<Rigidbody> option)
        {
            if (gameObject.TryGetComponent(out Rigidbody rigidbody) == false)
            {
                rigidbody = gameObject.AddComponent<Rigidbody>();
            }

            option?.Invoke(rigidbody);

            return rigidbody;
        }

        public static Rigidbody AddForce(this Rigidbody rigidbody, Vector3 force, ForceMode mode = ForceMode.Force)
        {
            rigidbody.AddForce(force, mode);

            return rigidbody;
        }

        public static Rigidbody Sleep(this Rigidbody rigidbody)
        {
            rigidbody.Sleep();
            return rigidbody;
        }

        public static Rigidbody ProjectileMotion(this Rigidbody rigidbody, Vector3 target, float angle = 45f)
        {
            var start = rigidbody.position;
            var rad = angle * Mathf.Deg2Rad;

            var horizontalDist = Vector2.Distance(new Vector2(start.x, start.z), new Vector2(target.x, target.z));

            // 垂直方向の距離y
            var verticalDist = start.y - target.y;

            // 斜方投射の公式を初速度について解く
            var speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(horizontalDist, 2) /
                                   (2 * Mathf.Pow(Mathf.Cos(rad), 2) *
                                    (horizontalDist * Mathf.Tan(rad) + verticalDist)));

            if (float.IsNaN(speed) == false)
            {
                var direction = new Vector3(target.x - start.x, horizontalDist * Mathf.Tan(rad), target.z - start.z);
                var velocity = direction.normalized * speed;
                rigidbody.AddForce(velocity * rigidbody.mass, ForceMode.Impulse);
            }

            return rigidbody;
        }
    }
}