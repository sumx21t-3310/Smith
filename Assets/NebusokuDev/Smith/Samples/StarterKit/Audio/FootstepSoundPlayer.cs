using NebusokuDev.Smith.Runtime.Sequence.Timer;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Audio
{
    public class FootstepPlayer : MonoBehaviour
    {
        [SerializeField] private Movement.Mover mover;
        [SerializeField] private Transform soundPoint;
        [SerializeField] private AudioClip[] jumpSound;
        [SerializeField] private AudioClip[] footstepSound;
        [SerializeReference] private IRpmTimer _rpm = new FixedRpmTimer();

        private bool _jumpSoundPlayed;

        private void Awake()
        {
            if (soundPoint == null)
            {
                soundPoint = transform;
            }
        }

        private void Update()
        {
            if (mover.IsGrounded == false && _jumpSoundPlayed == false)
            {
                PlaySound(footstepSound, soundPoint.position);

                _jumpSoundPlayed = true;
            }

            _rpm.Update();
            _jumpSoundPlayed = mover.IsGrounded;
            if (_rpm.IsOverTime == false) return;
            _rpm.Lap();
        }

        private void PlaySound(AudioClip[] clips, Vector3 position)
        {
            AudioSource.PlayClipAtPoint(clips[Random.Range(0, 10000) % clips.Length], position);
        }

        private void UpdateFootStep()
        {
            
        }
    }
}