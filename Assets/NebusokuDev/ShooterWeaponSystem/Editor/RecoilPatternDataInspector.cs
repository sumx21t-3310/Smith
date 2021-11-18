using NebusokuDev.ShooterWeaponSystem.Core.Recoil;
using UnityEditor;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Editor
{
    [CustomEditor(typeof(RecoilPatternData))]
    public class RecoilPatternDataInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var pattern = (RecoilPatternData) target;

            EditorGUILayout.LabelField("Recoil Pattern Graph");

            var rect = GUILayoutUtility.GetRect(100f, 200f);

            Vector3 current = Vector3.zero;
            rect.DrawVerticalLine();
            foreach (Vector2 dot in pattern.pattern)
            {
                current += new Vector3(dot.x, -dot.y) * rect.height / pattern.pattern.Length;
                rect.DrawWireDot(current + new Vector3(0f, rect.height / 2f));
            }
        }
    }
}