using System;
using System.Collections.Generic;
using NebusokuDev.Smith.Runtime.Recoil.RecoilProfile;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NebusokuDev.Smith.Editor.Generator.RecoilGenerateEngine
{
    [Serializable, AddTypeMenu("Perlin")]
    public class PerlinNoiseRecoilGenerateEngine : IRecoilGenerateEngine
    {
        [SerializeField] private float height = 35f;
        [SerializeField] private float step = 111f;
        [SerializeField] private float maxWidth = 1f;

        public IRecoilVector[] Generate(int length)
        {
            var recoils = new List<IRecoilVector>();

            for (int i = 0; i < length; i++)
            {
                float position = i * DateTime.Now.Millisecond;
                // horizontal pattern generate
                var horizontal = (Mathf.PerlinNoise(position, position * Random.Range(1f, 1.01f)) - .5f) * 2f;

                // vertical pattern generate
                var vertical = height / length;
                vertical *= Random.Range(.9f, 1f);

                recoils.Add(new FixedRecoilVector {Value = new Vector2(horizontal * maxWidth, vertical) * 10f});
            }

            return recoils.ToArray();
        }
    }
}