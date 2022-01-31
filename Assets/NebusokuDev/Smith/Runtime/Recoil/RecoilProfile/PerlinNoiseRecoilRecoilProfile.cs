using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Recoil
{
    [CreateAssetMenu]
    public class PerlinNoiseRecoilRecoilProfile : RecoilPatternProfileBase
    {
        [SerializeField] private float duration;
        [SerializeField] private Vector4 offset;
        [SerializeField] private float step = .1f;
        [SerializeField] private float power = 10f;

        public override Vector2 this[int index]
        {
            get
            {
                var x = (Mathf.PerlinNoise(index * step + offset.x, offset.y) - .5f) * 2f;
                var y = Mathf.PerlinNoise(index * step + offset.z, offset.w);

                Debug.Log($"x: {x}");
                Debug.Log($"y: {y}");

                return new Vector2(x, y) * power;
            }
        }

        public override float Duration => duration;
    }
}