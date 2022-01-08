using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool.Default
{
    public class AudioSourceDeactivator : MonoBehaviour
    {
        private AudioSource _src;

        private void Awake() => _src = GetComponent<AudioSource>();

        private void Update()
        {
            if (_src.isPlaying) return;
            gameObject.SetActive(false);
        }
    }
}