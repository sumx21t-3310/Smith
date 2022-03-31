using System;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;
using Random = UnityEngine.Random;

namespace NebusokuDev.Smith.Runtime.Recoil
{
    [Serializable, AddTypeMenu("Sin")]
    public class SinRecoil : IRecoil
    {
        [SerializeField] private float duration;
        [SerializeField] private float frequency = 2f;
        [SerializeField] private float upDegree = 1f;

        private float _easeTime;

        public void Reset()
        {
            var rotor = Locator<ICameraRotor>.Instance.Current;
            rotor.VerticalOffset = 0f;
            rotor.VerticalOffset = 0f;
        }

        void IRecoil.Reverse()
        {
            if (_easeTime > 0) return;
            var rotate = Locator<ICameraRotor>.Instance.Current;
            if (rotate == null) return;


            rotate.HorizontalOffset = Mathf.Lerp(rotate.HorizontalOffset, 0f, Time.deltaTime / duration);
            rotate.VerticalOffset = Mathf.Lerp(rotate.VerticalOffset, 0f, Time.deltaTime / duration);
        }

        void IRecoil.Generate(IWeaponContext context) => _easeTime = duration;

        void IRecoil.Easing()
        {
            if (_easeTime < 0f) return;
            var rotate = Locator<ICameraRotor>.Instance.Current;
            if (rotate == null) return;

            _easeTime -= Time.deltaTime;
            rotate.HorizontalOffset +=
                Mathf.Sin(Time.time * Mathf.PI * frequency) * Mathf.Deg2Rad * Time.deltaTime / duration;
            rotate.VerticalOffset += Random.value * upDegree * Mathf.Deg2Rad * Time.deltaTime / duration;
        }
    }
}