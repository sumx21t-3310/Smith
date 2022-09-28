using UnityEngine;

namespace NebusokuDev.Smith.Runtime.ProceduralAnimation.BobbingAnimation
{
    [CreateAssetMenu(menuName = "Smith/Bobbing/" + nameof(AnimationCurveBobbingProfile))]
    public class AnimationCurveBobbingProfile : WeaponBobbingProfileBase
    {
        [SerializeField] private float cycle = 2f;
        [SerializeField] private AnimationCurve positionX;
        [SerializeField] private AnimationCurve positionY;
        [SerializeField] private AnimationCurve positionZ;
        [SerializeField] private AnimationCurve rotationX;
        [SerializeField] private AnimationCurve rotationY;
        [SerializeField] private AnimationCurve rotationZ;

        public override (Vector3 rotation, Vector3 position) this[float time]
        {
            get
            {
                var phase = time * cycle % 1f;

                var position = new Vector3(positionX.Evaluate(phase), positionY.Evaluate(phase),
                    positionZ.Evaluate(phase));
                var rotation = new Vector3(rotationX.Evaluate(phase), rotationY.Evaluate(phase),
                    rotationZ.Evaluate(phase));

                return (rotation, position);
            }
        }
    }
}