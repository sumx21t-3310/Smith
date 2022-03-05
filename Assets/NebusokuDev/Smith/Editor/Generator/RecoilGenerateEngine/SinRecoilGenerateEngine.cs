using System;
using System.Collections.Generic;
using NebusokuDev.Smith.Runtime.Recoil.RecoilProfile;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NebusokuDev.Smith.Editor.Generator.RecoilGenerateEngine
{
    [Serializable, AddTypeMenu("Sin")]
    public class SinRecoilGenerateEngine : IRecoilGenerateEngine
    {
        [SerializeField] private float totalHeight = 35f;
        [SerializeField] private float maxWidth = 1f;
        [SerializeField] private AnimationCurve horizontalWeightCurve = AnimationCurve.EaseInOut(0f, 0.01f, 1f, 1f);

        public IRecoilVector[] Generate(int length)
        {
            var recoils = new List<IRecoilVector>();

            for (int i = 0; i < length; i++)
            {
                // horizontal pattern generate
                var horizontal = Mathf.Sin(i);
                horizontal *= horizontalWeightCurve.Evaluate(Random.value);
                horizontal *= maxWidth;

                // vertical pattern generate
                var vertical = totalHeight / length;
                vertical *= Random.Range(.9f, 1f);

                recoils.Add(new FixedRecoilVector {Value = new Vector2(horizontal, vertical) * 10f});
            }

            return recoils.ToArray();
        }
    }
}