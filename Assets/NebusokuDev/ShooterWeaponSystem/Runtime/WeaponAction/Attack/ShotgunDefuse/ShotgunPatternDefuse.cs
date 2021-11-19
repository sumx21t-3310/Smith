using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.ShotgunDefuse
{
    [CreateAssetMenu(menuName = "WeaponSystem/New ShotgunPatternDefuse")]
    public class ShotgunPatternDefuse : ShotgunDefuseBase, IEnumerable<Vector3>
    {
        [SerializeField] private Vector2[] pattern;
        [SerializeField] private float defuseWidth;
        [SerializeField] private float defuseDistance;

        public IEnumerator<Vector3> GetPattern()
        {
            foreach (var offset in pattern)
            {
                yield return offset * (defuseWidth / defuseDistance);
            }
        }

        public override IEnumerator<Vector3> GetEnumerator() => GetPattern();
        IEnumerator IEnumerable.GetEnumerator() => GetPattern();
    }
}