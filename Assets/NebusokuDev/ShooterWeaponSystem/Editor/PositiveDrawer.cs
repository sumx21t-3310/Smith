using NebusokuDev.ShooterWeaponSystem.Core.Attribute;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUI;

namespace NebusokuDev.ShooterWeaponSystem.Editor
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