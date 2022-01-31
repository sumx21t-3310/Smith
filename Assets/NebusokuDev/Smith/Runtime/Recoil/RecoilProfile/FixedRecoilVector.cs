using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Recoil.RecoilProfile
{
    [Serializable]
    public class FixedRecoilVector : IRecoilVector
    {
        [SerializeField] private Vector2 value;

        public Vector2 Value
        {
            get => value;
            set => this.value = value;
        }
    }
}