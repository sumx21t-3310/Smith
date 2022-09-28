using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.ProceduralAnimation
{
    public class FovKickBack : MonoBehaviour, IProceduralAnimation
    {
        [SerializeField] private float kickBack = 1.1f;
        [SerializeField, Range(0.01f, 10f)] private float duration = .05f;

        private float _current = 1f;

        private void Update()
        {
            _current = Mathf.SmoothStep(_current, 1f, Time.deltaTime / duration);
            Locator<IReferenceCamera>.Instance.Current.VirtualFov[this] = _current;
        }

        public void Play()
        {
            _current = kickBack;
            Locator<IReferenceCamera>.Instance.Current.VirtualFov[this] = _current;
        }
    }
}