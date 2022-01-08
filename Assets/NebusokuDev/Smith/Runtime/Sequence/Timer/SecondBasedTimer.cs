using System;
using NebusokuDev.Smith.Runtime.Attribute;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Sequence.Timer
{
    [Serializable, AddTypeMenu("Second")]
    public class SecondBasedTimer : IRpmTimer
    {
        [SerializeField, Abs] private float waitTime = 1f;
        private float _intervalCounter;
        public bool IsOverTime => _intervalCounter > waitTime;

        public void Update() => _intervalCounter += IsOverTime ? 0f : Time.deltaTime;

        public void Reset() { }

        public void Lap() => _intervalCounter = 0f;
    }
}