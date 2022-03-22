using System.Linq;
using NebusokuDev.Smith.Runtime.Sequence.Timer;
using NebusokuDev.Smith.Samples.StarterKit.Movement;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Audio
{
    public class FootstepSoundPlayer : MonoBehaviour
    {
        [SerializeField] private Mover mover;
        [SerializeField] private float minMoveSqrMagnitude = 1f;
        [SerializeField] private Transform soundPoint;
        [SerializeField] private AudioClip[] clips;
        [SerializeReference] private IRpmTimer _rpm = new FixedRpmTimer();

        private void Awake()
        {
            if (mover == null)
            {
                mover = GetComponent<Mover>();
            }


            if (soundPoint == null)
            {
                soundPoint = transform;
            }
        }

        private void Update()
        {
            if (mover.IsGrounded == false) return;
            if (mover.Velocity.sqrMagnitude < minMoveSqrMagnitude) return;

            _rpm.Update();

            if (_rpm.IsOverTime == false) return;

            if (clips.Any())
            {
                AudioSource.PlayClipAtPoint(clips[Random.Range(0, 10000) % clips.Length], soundPoint.position);
            }

            _rpm.Lap();
        }
    }
}