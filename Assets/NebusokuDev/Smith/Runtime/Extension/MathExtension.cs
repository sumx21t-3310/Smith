using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Extension
{
    public struct MathExtension
    {
        public static Vector2 Degree2Vector2(float degree) => Radian2Vector2(degree * Mathf.Deg2Rad);

        public static Vector2 Radian2Vector2(float radian) => new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
}