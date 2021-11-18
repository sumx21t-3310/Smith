using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Aim
{
    public class Sight : MonoBehaviour
    {
        [SerializeField] private float[] fovScales = {.9f};
        [SerializeField] private int fovScaleIndex;
        [SerializeField] private Transform aimPoint;
        [SerializeField] private float duration = .1f;
        [SerializeField] private GameObject[] sightModels;

        public float Duration => duration;

        public Transform AimPoint => aimPoint;
        public float ZoomMultiples => fovScales[fovScaleIndex % fovScales.Length];

        public void FovScaleChange() => fovScaleIndex = ++fovScaleIndex % fovScales.Length;


        private void OnEnable()
        {
            foreach (var model in sightModels) model.SetActive(true);
        }


        private void OnDisable()
        {
            foreach (var model in sightModels) model.SetActive(false);
        }
    }
}