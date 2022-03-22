using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Sequence.Timer
{
    [Serializable, AddTypeMenu("Second")]
    public class SecondBasedTimer : IRpmTimer
    {
        [SerializeField] private float waitTime = 1f;
        private float _lastPlayedTime;
        public bool IsOverTime => Time.time - _lastPlayedTime > waitTime;

        public void Update()
        {
        }

        public void Reset()
        {
        }

        public void Lap() => _lastPlayedTime = Time.time;
    }
}