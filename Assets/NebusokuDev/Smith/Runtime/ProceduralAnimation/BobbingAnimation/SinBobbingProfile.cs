using System.Reflection;
using UnityEngine;
using static UnityEngine.Mathf;

namespace NebusokuDev.Smith.Runtime.ProceduralAnimation.BobbingAnimation
{
    [CreateAssetMenu(menuName= "")]
    public class SinBobbingProfile : WeaponBobbingProfileBase
    {
        [SerializeField] private float cycle = 2f;
        [SerializeField] private Vector3 positionScale = Vector3.one * .01f;
        [SerializeField] private float rotationScale = .1f;

        public override (Vector3 rotation, Vector3 position) this[float time]
        {
            get
            {
                return (Vector3.zero, Vector3.zero);
            }
        }
    }
}