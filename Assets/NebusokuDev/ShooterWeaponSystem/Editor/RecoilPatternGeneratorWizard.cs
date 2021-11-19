using NebusokuDev.ShooterWeaponSystem.Runtime.Recoil;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NebusokuDev.ShooterWeaponSystem.Editor
{
    public class RecoilPatternGeneratorWizard : ScriptableWizard
    {
        [SerializeField] private string weaponName ="New DualActionWeapon Recoil Pattern";
        [SerializeField] private int len = 35;
        [SerializeField] private float height = 35f;
        [SerializeField] private float maxWidth = 1f;
        [SerializeField] private AnimationCurve horizontalWeightCurve = AnimationCurve.EaseInOut(0f, 0.01f, 1f, 1f);
        private Vector2[] _temp;

        [MenuItem("WeaponSystem/Recoil Pattern Generator ")]
        public static void CreateWizard()
        {
            DisplayWizard<RecoilPatternGeneratorWizard>("Recoil Pattern Generator ", "Create");
        }

        public void OnWizardCreate()
        {
            var recoilPattern = CreateInstance<RecoilPatternData>();
            recoilPattern.pattern = CreateRecoilPattern(len);
            var path =AssetDatabase.GenerateUniqueAssetPath($"Assets/{weaponName}.asset");
            AssetDatabase.CreateAsset(recoilPattern, path);
            AssetDatabase.Refresh();
        }

        private void OnWizardOtherButton()
        {
            _temp = CreateRecoilPattern(len);
        }

        Vector2[] CreateRecoilPattern(int length)
        {
            var pattern = new Vector2[length];
            for (int i = 1; i <= pattern.Length; i++)
            {
                // horizontal pattern generate
                var horizontal = Mathf.Sin(i);
                horizontal *= horizontalWeightCurve.Evaluate(Random.value);
                horizontal *= maxWidth;

                // vertical pattern generate
                var vertical = height / length;
                vertical *= Random.Range(.9f, 1f);

                pattern[i - 1] = new Vector2(horizontal, vertical);
            }

            return pattern;
        }
    }
}