using System;
using NebusokuDev.Smith.Runtime.State.Player;
using UnityEngine;
using static UnityEngine.Mathf;
using static UnityEngine.Random;
using static UnityEngine.AnimationCurve;
using Random = System.Random;


namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle.Spread
{
    [Serializable, AddTypeMenu("Random")]
    public class RandomSpread : ISpread
    {
        public static readonly RandomSpread Default = new RandomSpread();

        [SerializeField] private PlayerMovementContext context = PlayerMovementContext.Rest;
        [SerializeField, Range(0f, 100f)] private float startMoa = 5f;
        [SerializeField, Range(0f, 100f)] private float endMoa = 10f;
        [SerializeField, Range(0f, 2f)] private float aimingSpreadMultiple;
        [SerializeField] private AnimationCurve verticalWeightCurve = Constant(0f, 1f, 1f);
        [SerializeField] private AnimationCurve horizontalWeightCurve = Constant(0f, 1f, 1f);

        public PlayerMovementContext Context => context;


        public Vector3 Defuse(bool isAim, float t)
        {
            var unitCircle = insideUnitCircle;

            var horizontal = CalcSpread(unitCircle.x, horizontalWeightCurve);
            var vertical = CalcSpread(unitCircle.y, verticalWeightCurve);

            var defuse = new Vector3(horizontal, vertical);

            var moa = CalcMoa(Lerp(startMoa, endMoa, t));
            moa *= isAim ? aimingSpreadMultiple : 1f;

            return defuse * moa + Vector3.forward;
        }

        float Pulse(float t) => t > 0f ? 1f : -1f;

        private float CalcSpread(float t, AnimationCurve curve) => Pulse(t) * curve.Evaluate(Abs(t));


        /*
         * 1moa = 100mで2.9cm以内
         * https://en.wikipedia.org/wiki/Minute_and_second_of_arc#FirearmsM.O.A.
         */
        private float CalcMoa(float angle) => angle * (0.29f / 100f);
    }
}