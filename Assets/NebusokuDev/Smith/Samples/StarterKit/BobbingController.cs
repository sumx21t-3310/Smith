using NebusokuDev.Smith.Runtime.ProceduralAnimation.BobbingAnimation;
using NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit
{
    public class BobbingController : MonoBehaviour
    {
        [SerializeField] private MonolithicMover mover;
        [SerializeField] private Bobbing bobbing;

        private float _weight;

        private void Update()
        {
            bobbing.Weight = Mathf.SmoothStep(bobbing.Weight, GetWeight(), Time.deltaTime / .025f);
        }


        private float GetWeight()
        {
            if (mover.Velocity.magnitude < 1f) return 0f;

            return mover.IsGrounded ? 1f : 0f;
        }
    }
}