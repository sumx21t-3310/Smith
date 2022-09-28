using UnityEngine;
using System;

namespace NebusokuDev.Smith.Runtime.Sequence.Timer
{
    [Serializable]
    public class AccelerateTickTimer2 : ITickTimer
    {
        [SerializeField, Range(10f, 2000f)] private float rpm;
        private const float Minute = 60f;

        private float _elapsedTime;
        public bool IsOverTime => GetTime() - _elapsedTime > Minute / rpm;
        public void Update() { }

        public void Reset() { }

        public void Lap() => _elapsedTime = GetTime();

        protected virtual float GetTime() => Time.time;
    }
}