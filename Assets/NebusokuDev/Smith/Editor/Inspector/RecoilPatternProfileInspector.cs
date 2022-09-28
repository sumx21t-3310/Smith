using NebusokuDev.Smith.Runtime.Recoil.RecoilProfile;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace NebusokuDev.Smith.Editor.Inspector
{
    [CustomEditor(typeof(PatternRecoilProfile))]
    public class RecoilPatternProfileInspector : UnityEditor.Editor
    {
        private Rect _rect;
        private PatternRecoilProfile _profile;
        private float _scale = .1f;
        private Vector3 _current;

        // public override void OnInspectorGUI()
        // {
        //     base.OnInspectorGUI();
        //
        //
        //     if (_profile == null)
        //     {
        //         _profile = (PatternRecoilProfile) target;
        //     }
        //
        //
        //     EditorGUILayout.LabelField("Recoil Pattern Graph");
        //
        //     _rect = GUILayoutUtility.GetRect(100f, 200f);
        //     Vector3 current = Vector3.zero;
        //     _rect.DrawVerticalLine();
        //
        //
        //     foreach (var dot in _profile.Pattern)
        //     {
        //         var value = dot?.Value ?? Vector2.zero;
        //         current += new Vector3(value.x, -value.y) * _rect.height / _profile.Pattern.Length * _scale;
        //         _rect.DrawWireDot(current + new Vector3(0f, _rect.height / 2f));
        //     }
        // }

        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            root.Add(new IMGUIContainer(() => DrawDefaultInspector()));

            var box = new Box();
            box.Add(new Label("Recoil Pattern Graph"));


            box.Add(new IMGUIContainer(() =>
            {
                if (_profile == null)
                {
                    _profile = (PatternRecoilProfile) target;
                }

                _rect = GUILayoutUtility.GetRect(100f, 200f);
                Vector3 current = Vector3.zero;
                _rect.DrawVerticalLine();

                foreach (var dot in _profile.Pattern)
                {
                    var value = dot?.Value ?? Vector2.zero;
                    current += new Vector3(value.x, -value.y) * _rect.height / _profile.Pattern.Length * _scale;
                    _rect.DrawWireDot(current + new Vector3(0f, _rect.height / 2f));
                }
            }));
            root.Add(box);

            return root;
        }
    }
}