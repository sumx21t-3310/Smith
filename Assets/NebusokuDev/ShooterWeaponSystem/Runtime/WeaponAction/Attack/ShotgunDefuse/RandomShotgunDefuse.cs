using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.ShotgunDefuse
{
    [CreateAssetMenu(menuName = "WeaponSystem/New RandomShotgunDefuse")]
    public class RandomShotgunDefuse : ShotgunDefuseBase, IEnumerable
    {
        [SerializeField] private int shotgunPellet = 3;
        [SerializeField] private AnimationCurve randomWeightCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        [SerializeField] private float defuseDistance = 10f;
        [SerializeField] private float defuseRadius = .5f;

        public override IEnumerator<Vector3> GetEnumerator()
        {
            for (int i = 0; i < shotgunPellet; i++)
            {
                var rand = insideUnitCircle;
                rand *= randomWeightCurve.Evaluate(value);
                yield return rand * (defuseRadius / defuseDistance);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}