using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace NebusokuDev.Smith.Runtime.Recoil
{
    [Serializable]
    public class RandomRecoilVector : IRecoilVector
    {
        [SerializeField] private float up;
        [SerializeField] private float down;
        [SerializeField] private float left;
        [SerializeField] private float right;
        
        public Vector2 Value => new Vector2(Random.Range(left, right), Random.Range(down, up));
    }
}