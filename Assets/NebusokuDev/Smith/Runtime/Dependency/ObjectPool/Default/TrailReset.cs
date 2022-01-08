using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool.Default
{
    public class TrailReset : MonoBehaviour
    {
        private TrailRenderer _renderer;

        private void Awake() => _renderer = GetComponent<TrailRenderer>();

        private void OnDisable() => _renderer.Clear();
    }
}