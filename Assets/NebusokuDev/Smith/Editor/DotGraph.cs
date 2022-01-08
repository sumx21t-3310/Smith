using UnityEditor;
using UnityEngine;

namespace NebusokuDev.Smith.Editor
{
    public static class DotGraph
    {
        public static void DrawSolidDot(this Rect rect, Vector3 position)
        {
            Handles.DrawSolidDisc((Vector3) rect.center + position, Vector3.forward, 2f);
        }

        public static void DrawWireDot(this Rect rect, Vector3 position)
        {
            Handles.DrawWireDisc((Vector3)rect.center + position, Vector3.forward, 2f);
        }

        public static void DrawHorizontalLine(this Rect rect)
        {
            Vector3 left = rect.center - new Vector2(rect.width / 2f, 0f);
            Vector3 right = rect.center + new Vector2(rect.width / 2f, 0f);
            Handles.DrawLine(left, right);
        }

        public static void DrawVerticalLine(this Rect rect)
        {
            Vector3 top = rect.center - new Vector2(0f, rect.height / 2);
            Vector3 bottom = rect.center + new Vector2(0f, rect.height / 2);
            Handles.DrawLine(top, bottom);
        }
    }
}