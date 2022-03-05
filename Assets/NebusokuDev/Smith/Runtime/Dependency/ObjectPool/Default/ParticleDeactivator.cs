using NebusokuDev.Smith.Runtime.Extension;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool.Default
{
    public class ParticleDeactivator : MonoBehaviour
    {
        private ParticleSystem _particle;

        private void Awake() => _particle = GetComponent<ParticleSystem>();

        private void Update()
        {
            if (_particle.isPlaying) return;
            gameObject.LightSetActive(false);
        }
    }
}