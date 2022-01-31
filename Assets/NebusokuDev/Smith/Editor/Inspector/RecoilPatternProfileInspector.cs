using System.Linq;
using NebusokuDev.Smith.Runtime.Recoil;
using NebusokuDev.Smith.Runtime.Recoil.RecoilProfile;
using UnityEditor;
using UnityEngine;

namespace NebusokuDev.Smith.Editor.Inspector
{
    [CustomEditor(typeof(PatternRecoilProfile))]
    public class RecoilPatternProfileInspector : UnityEditor.Editor
    {
        private Rect _rect;
        private PatternRecoilProfile _profile;

        private int _flameCount;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _profile = (PatternRecoilProfile) target;

            EditorGUILayout.LabelField("Recoil Pattern Graph");

            _rect = GUILayoutUtility.GetRect(100f, 200f);
            Vector3 current = Vector3.zero;
            _rect.DrawVerticalLine();

            var dots = _profile.Pattern.Where(x => x != null).Select(vector => vector.Value).ToArray();

            foreach (var dot in dots)
            {
                current += new Vector3(dot.x, -dot.y) * _rect.height / dots.Length;
                _rect.DrawWireDot(current + new Vector3(0f, _rect.height / 2f));
            }
        }
    }
}