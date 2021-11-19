using System;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Sequence.FireMode
{
    [Serializable, AddTypeMenu("SemiAuto")]
    public class SemiAuto : IFireMode
    {
        private bool _isKeyUp;

        public bool Evaluate(bool input)
        {
            if (input == false)
            {
                _isKeyUp = true;
                return false;
            }

            if (_isKeyUp == false) return false;

            _isKeyUp = false;

            return true;
        }
    }
}