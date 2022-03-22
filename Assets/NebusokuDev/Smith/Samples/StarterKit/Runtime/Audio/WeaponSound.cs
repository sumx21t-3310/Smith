using System.Linq;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Audio
{
    public class WeaponSound : MonoBehaviour
    {
        [SerializeField] private AudioClip[] shotSoundClips;
        [SerializeField] private Transform muzzle;

        public void Play()
        {
            if (shotSoundClips.Any() == false) return;

            AudioSource.PlayClipAtPoint(shotSoundClips[Random.Range(0, 10000) % shotSoundClips.Length], muzzle.position);
        }
    }
}