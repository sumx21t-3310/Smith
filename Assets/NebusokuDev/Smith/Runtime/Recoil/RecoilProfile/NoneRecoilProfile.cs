using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Recoil
{
    public class NoneRecoilProfile : RecoilPatternProfileBase
    {
        [SerializeField] private float duration;
        public override Vector2 this[int index] => Vector2.zero;
        public override float Duration => duration;
    }
}