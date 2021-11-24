using System;
using System.Linq;
using NebusokuDev.ShooterWeaponSystem.Runtime.Recoil;
using UnityEditor;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Editor
{
    [CustomEditor(typeof(RecoilPatternData))]
    public class RecoilPatternDataInspector : UnityEditor.Editor
    {
        private Rect _rect;
        private RecoilPatternData _patternData;


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _patternData = (RecoilPatternData)target;

            EditorGUILayout.LabelField("Recoil Pattern Graph");

            _rect = GUILayoutUtility.GetRect(100f, 200f);
            Vector3 current = Vector3.zero;
            _rect.DrawVerticalLine();

            foreach (Vector2 dot in _patternData.pattern.Where(x => x != null).Select(vector => vector.Value))
            {
                current += new Vector3(dot.x, -dot.y) * _rect.height / _patternData.pattern.Length;
                _rect.DrawWireDot(current + new Vector3(0f, _rect.height / 2f));
            }
        }
    }
}