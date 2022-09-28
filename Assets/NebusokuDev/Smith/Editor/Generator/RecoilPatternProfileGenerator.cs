using NebusokuDev.Smith.Editor.Generator.RecoilGenerateEngine;
using NebusokuDev.Smith.Runtime.Recoil.RecoilProfile;
using UnityEditor;
using UnityEngine;


namespace NebusokuDev.Smith.Editor.Generator
{
    public class RecoilPatternProfileGenerator : ScriptableWizard
    {
        [SerializeField] private string weaponName = "New Weapon Recoil Pattern";
        [SerializeField] private int length = 35;
        [SerializeReference, SubclassSelector] private IRecoilGenerateEngine _engine = new SinRecoilGenerateEngine();

        [MenuItem("Tools/Smith/Recoil Pattern Generator")]
        public static void CreateWizard()
        {
            DisplayWizard<RecoilPatternProfileGenerator>($"{nameof(PatternRecoilProfile)}Generator", "Generate");
        }


        public void OnWizardCreate()
        {
            var recoilPattern = CreateInstance<PatternRecoilProfile>();
            recoilPattern.Pattern = _engine?.Generate(length);

            var fullPath = AssetDatabase.GenerateUniqueAssetPath($"Assets/{weaponName}.asset");

            AssetDatabase.CreateAsset(recoilPattern, fullPath);
            AssetDatabase.Refresh();
        }
    }
}