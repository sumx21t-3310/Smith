using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.Camera
{
    public abstract class ReferenceCameraBase : MonoBehaviour, IReferenceCamera
    {
        public static float FieldOfView
        {
            get => _fieldOfView;
            set => _fieldOfView = Mathf.Clamp(Mathf.Abs(value), 0.01f, 170f);
        }

        private static float _fieldOfView = 60f;

        public abstract float FovScale { get; set; }

        public abstract UnityEngine.Camera Camera { get; }

        public abstract Transform Center { get; }
    }
}