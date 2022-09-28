using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Sequence.FireMode
{
    [Serializable, AddTypeMenu("Burst")]
    public class Burst : IFireMode
    {
        [SerializeField] private int maxCount = 3;
        private int _count;
        private bool _isKeyUp;

        public bool Evaluate(bool input)
        {
            _count = --_count % maxCount;

            if (input == false)
            {
                _isKeyUp = true;
                return _count > 0;
            }

            if (_isKeyUp == false) return _count > 0;

            _count = maxCount;
            _isKeyUp = false;

            return _count > 0;
        }
    }
}