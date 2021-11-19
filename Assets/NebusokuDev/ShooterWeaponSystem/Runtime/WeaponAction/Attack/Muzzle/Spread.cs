using System;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Player;
using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Random;
using static UnityEngine.AnimationCurve;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.Muzzle
{
    [Serializable]
    public class Spread
    {
        public static readonly Spread Default = new Spread();
        [SerializeField] private PlayerMovementContext context = PlayerMovementContext.Rest;
        [SerializeField, Range(0f, 100f)] private float startMOA = 5f;
        [SerializeField, Range(0f, 100f)] private float endMOA = 10f;
        [SerializeField, Range(0f, 2f)] private float aimingSpreadMultiple;
        [SerializeField] private AnimationCurve verticalWeightCurve = Constant(0f, 1f, 1f);
        [SerializeField] private AnimationCurve horizontalWeightCurve = Constant(0f, 1f, 1f);

        public PlayerMovementContext Context => context;


        public Vector3 Defuse(bool isAim, float t)
        {
            var defuse = new Vector3(Range(-1f, 1f), Range(-1f, 1f));
            defuse.y *= horizontalWeightCurve.Evaluate(Abs(defuse.y));
            defuse.x *= verticalWeightCurve.Evaluate(Abs(defuse.x));

            var moa = CalcMOA(Lerp(startMOA, endMOA, t));
            moa *= isAim ? aimingSpreadMultiple : 1f;

            return defuse * moa;
        }


        /*
         * 1moa = 100mで2.9cm以内
         * https://en.wikipedia.org/wiki/Minute_and_second_of_arc#FirearmsM.O.A.
         */
        private float CalcMOA(float angle) => angle * (0.29f / 100f);
    }
}