using NebusokuDev.ShooterWeaponSystem.Core.Attribute;
using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUI;

namespace NebusokuDev.ShooterWeaponSystem.Editor
{
    [CustomPropertyDrawer(typeof(TagFieldAttribute))]
    public class TagFieldDrawer : PropertyDrawer
    {
        private const float HSpace = 2;

        private string _tagValue = string.Empty;

        private readonly GUIContent _clearText = new GUIContent("Clear", "Set the tag to empty");

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var textDimensions = GUI.skin.button.CalcSize(_clearText);

            position.width -= textDimensions.x + HSpace;
            _tagValue = property.stringValue;
            showMixedValue = property.hasMultipleDifferentValues;
            
            BeginChangeCheck();
            _tagValue = TagField(position, label, _tagValue);
            
            if (EndChangeCheck()) property.stringValue = _tagValue;

            showMixedValue = false;

            position.x += position.width + HSpace;
            position.width = textDimensions.x;
            position.height -= 1;
            GUI.enabled = _tagValue.Length > 0;
            if (GUI.Button(position, _clearText)) property.stringValue = string.Empty;

            GUI.enabled = true;
        }
    }
}