using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Camera
{
    public interface IReferenceCamera
    {
        public float FovScale { get; set; }

        public UnityEngine.Camera Camera { get; }

        public Transform Center { get; }
    }
}