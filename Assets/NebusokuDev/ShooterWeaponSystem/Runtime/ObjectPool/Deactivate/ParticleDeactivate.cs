using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.ObjectPool.Deactivate
{
    public class ParticleDeactivate : MonoBehaviour
    {
        private ParticleSystem _particle;

        private void Awake() => _particle = GetComponent<ParticleSystem>();

        private void Update()
        {
            if (_particle.isPlaying) return;
            gameObject.SetActive(false);
        }
    }
}