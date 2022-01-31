using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Recoil.RecoilProfile
{
    [CreateAssetMenu(menuName = "Smith/RecoilProfile/" + nameof(PerlinNoiseRecoilRecoilProfile))]
    public class PerlinNoiseRecoilRecoilProfile : RecoilPatternProfileBase
    {
        [SerializeField] private float duration = .1f;
        [SerializeField] private Vector4 offset;
        [SerializeField] private Vector2 timeStep = Vector2.one;
        [SerializeField] private float power = 10f;

        public override Vector2 this[int index]
        {
            get
            {
                var x =
                    (Mathf.PerlinNoise(Time.time * timeStep.x + offset.x, Time.time * timeStep.x + offset.y) - .5f) *
                    2f;
                var y = Mathf.PerlinNoise(Time.time * timeStep.x + offset.z, Time.time * timeStep.x + offset.w);

                return new Vector2(x, y) * power;
            }
        }

        public override float Duration => duration;
    }
}