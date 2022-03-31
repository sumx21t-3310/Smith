using NebusokuDev.Smith.Runtime.Camera;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Debug
{
    public class FovSetter : MonoBehaviour
    {
        [SerializeField, Range(60f, 180f)] private float horizontalFov = 103f;


#if DEBUG
        private void OnValidate()
        {
            ReferenceCameraBase.FieldOfView.Horizontal = horizontalFov;
        }

        private void Awake()
        {
            ReferenceCameraBase.FieldOfView.Horizontal = horizontalFov;
        }
#endif
    }
}