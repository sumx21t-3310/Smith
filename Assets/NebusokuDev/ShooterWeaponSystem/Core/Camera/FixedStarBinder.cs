using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.Camera
{
    public class FixedStarBinder : MonoBehaviour
    {
        private void Awake()
        {
            var fixedStar = GetComponent<ICameraFixedStar>();
            Locator<ICameraFixedStar>.Instance.Bind(fixedStar);
        }


        private void OnEnable()
        {
            var fixedStar = GetComponent<ICameraFixedStar>();
            Locator<ICameraFixedStar>.Instance.Bind(fixedStar);
        }


        private void OnDisable()
        {
            var fixedStar = GetComponent<ICameraFixedStar>();
            Locator<ICameraFixedStar>.Instance.Unbind(fixedStar);
        }
    }
}