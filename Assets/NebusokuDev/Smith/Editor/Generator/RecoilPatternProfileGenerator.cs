using NebusokuDev.Smith.Runtime.Recoil;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;


namespace NebusokuDev.Smith.Editor.Generator
{
    public class RecoilPatternProfileGenerator : ScriptableWizard
    {
        [SerializeField] private string weaponName = "New DualActionWeapon Recoil Pattern";
        [SerializeField] private int len = 35;
        [SerializeField] private float height = 35f;
        [SerializeField] private float maxWidth = 1f;
        [SerializeField] private AnimationCurve horizontalWeightCurve = AnimationCurve.EaseInOut(0f, 0.01f, 1f, 1f);

        [MenuItem("WeaponSystem/Recoil Pattern Generator")]
        public static void CreateWizard()
        {
            DisplayWizard<RecoilPatternProfileGenerator>($"{nameof(RecoilPatternProfile)}Generator", "Generate");
        }


        public void OnWizardCreate()
        {
            var recoilPattern = CreateInstance<RecoilPatternProfile>();
            recoilPattern.pattern = CreateRecoilPattern(len);
            var path = AssetDatabase.GenerateUniqueAssetPath($"Assets/{weaponName}.asset");
            AssetDatabase.CreateAsset(recoilPattern, path);
            AssetDatabase.Refresh();
        }


        IRecoilVector[] CreateRecoilPattern(int length)
        {
            var pattern = new IRecoilVector[length];

            for (int i = 1; i <= pattern.Length; i++)
            {
                // horizontal pattern generate
                var horizontal = Mathf.Sin(i);
                horizontal *= horizontalWeightCurve.Evaluate(Random.value);
                horizontal *= maxWidth;

                // vertical pattern generate
                var vertical = height / length;
                vertical *= Random.Range(.9f, 1f);

                pattern[i - 1] = new FixedRecoilVector {Value = new Vector2(horizontal, vertical) * 10f};
            }

            return pattern;
        }
    }
}