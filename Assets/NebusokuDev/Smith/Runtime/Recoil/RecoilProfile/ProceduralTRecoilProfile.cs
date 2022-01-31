using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Recoil.RecoilProfile
{
    [CreateAssetMenu(menuName = "Smith/RecoilProfile/ValorantRecoilProfile")]
    public class ProceduralTRecoilProfile : RecoilPatternProfileBase
    {
        [SerializeField] private float horizontalSpeed = 2f;
        [SerializeField] private float duration = .1f;
        [SerializeField] private Vector2Int shotLimit = new Vector2Int(10, 10);
        [SerializeField] private Vector2 scale = Vector2.one;


        public override Vector2 this[int index]
        {
            get
            {
                var up = scale.y * shotLimit.y / (index + 1f);
                var horizontal = scale.x * horizontalSpeed * Mathf.Sin(Time.time * horizontalSpeed) * Random.value *
                                 Mathf.Clamp01(index / shotLimit.x);
                return new Vector2(horizontal, up);
            }
        }

        public override float Duration => duration;
    }
}