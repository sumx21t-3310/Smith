using System;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Recoil
{
    [Serializable, AddTypeMenu("Pattern")]
    public class PatternRecoil : IRecoil
    {
        [SerializeField] private RecoilPatternProfile patternProfile;
        [SerializeField] private float duration = .1f;

        private int _index;
        private float _easeTime;


        public void Reset()
        {
            _index = 0;

            if (_easeTime > 0) return;

            var rotate = Locator<ICameraRotor>.Instance.Current;

            if (rotate == null) return;

            rotate.HorizontalOffset = Mathf.Lerp(rotate.HorizontalOffset, 0f, Time.deltaTime / duration);
            rotate.VerticalOffset = Mathf.Lerp(rotate.VerticalOffset, 0f, Time.deltaTime / duration);
        }


        public void Generate(IWeaponContext context)
        {
            _index = context.ShotCount;
            _easeTime = duration;
        }


        public void Easing()
        {
            if (_easeTime < 0f) return;

            var rotate = Locator<ICameraRotor>.Instance.Current;

            if (rotate == null) return;

            _easeTime -= Time.deltaTime;
            rotate.HorizontalOffset += patternProfile[_index].x * Mathf.Deg2Rad * Time.deltaTime / duration;
            rotate.VerticalOffset += patternProfile[_index].y * Mathf.Deg2Rad * Time.deltaTime / duration;
        }
    }
}