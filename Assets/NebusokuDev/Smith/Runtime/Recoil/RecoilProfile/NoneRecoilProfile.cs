using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Recoil.RecoilProfile
{
    [CreateAssetMenu(menuName = "Smith/RecoilProfile/" + nameof(NoneRecoilProfile))]
    public class NoneRecoilProfile : RecoilPatternProfileBase
    {
        [SerializeField] private float duration = .1f;
        public override Vector2 this[int index] => Vector2.zero;
        public override float Duration => duration;
    }
}