using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Sequence.Timer
{
    [Serializable, AddTypeMenu("Accelerate")]
    public class AccelerateRpmTimer : IRpmTimer
    {
        [SerializeField] private AnimationCurve rpm = AnimationCurve.Constant(0f, 1f, 600f);
        [SerializeField] private float resetDuration = .2f;
        private const float Minute = 60f;

        private float _intervalCounter;
        private float _time;

        public bool IsOverTime => _intervalCounter > Minute / rpm.Evaluate(_time);
        
        public void Update() => _intervalCounter += IsOverTime ? 0f : Time.deltaTime;

        public void Reset() => _time = Mathf.Lerp(_time, 0f, Time.deltaTime / resetDuration);

        public void Lap()
        {
            _time += _intervalCounter;
            _intervalCounter = 0f;
        }
    }
}