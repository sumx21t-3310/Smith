using System.Linq;
using NebusokuDev.Smith.Runtime.Recoil;
using UnityEditor;
using UnityEngine;

namespace NebusokuDev.Smith.Editor
{
    [CustomEditor(typeof(RecoilPatternProfile))]
    public class RecoilPatternDataInspector : UnityEditor.Editor
    {
        private Rect _rect;
        private RecoilPatternProfile _patternProfile;


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _patternProfile = (RecoilPatternProfile)target;

            EditorGUILayout.LabelField("Recoil Pattern Graph");

            _rect = GUILayoutUtility.GetRect(100f, 200f);
            Vector3 current = Vector3.zero;
            _rect.DrawVerticalLine();

            foreach (Vector2 dot in _patternProfile.pattern.Where(x => x != null).Select(vector => vector.Value))
            {
                current += new Vector3(dot.x, -dot.y) * _rect.height / _patternProfile.pattern.Length;
                _rect.DrawWireDot(current + new Vector3(0f, _rect.height / 2f));
            }
        }
    }
}