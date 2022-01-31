using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Recoil.RecoilProfile
{
    [CreateAssetMenu(menuName = "Smith/RecoilProfile/" + nameof(PatternRecoilProfile))]
    public class PatternRecoilProfile : RecoilPatternProfileBase
    {
        [SerializeField, Range(float.Epsilon, 10f)]
        private float duration = .1f;

        [SerializeReference, SubclassSelector] public IRecoilVector[] Pattern;
        public override Vector2 this[int index] => Pattern[index % Pattern.Length].Value;
        public override float Duration => duration;
    }
}