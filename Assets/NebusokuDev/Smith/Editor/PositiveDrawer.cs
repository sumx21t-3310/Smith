using NebusokuDev.Smith.Runtime.Attribute;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUI;

namespace NebusokuDev.Smith.Editor
{
    [CustomPropertyDrawer(typeof(AbsAttribute))]
    public class PositiveDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.floatValue = FloatField(position, Mathf.Clamp(property.floatValue, 0f, float.MaxValue));
        }
    }
}