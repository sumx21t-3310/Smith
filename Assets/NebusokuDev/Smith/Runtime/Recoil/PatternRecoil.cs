using System;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.Recoil.RecoilProfile;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Recoil
{
    [Serializable, AddTypeMenu("Pattern")]
    public class PatternRecoil : IRecoil
    {
        [SerializeField] private RecoilPatternProfileBase recoilProfile;
        [SerializeField] private float scale = .1f;

        private int _index;
        private float _easeTime;


        public void Reset()
        {
            _index = 0;

            if (_easeTime > 0) return;

            var rotator = Locator<ICameraRotor>.Instance.Current;

            if (rotator == null) return;

            rotator.HorizontalOffset =
                Mathf.Lerp(rotator.HorizontalOffset, 0f, Time.deltaTime / recoilProfile.Duration);
            rotator.VerticalOffset = Mathf.Lerp(rotator.VerticalOffset, 0f, Time.deltaTime / recoilProfile.Duration);
        }


        public void Generate(IWeaponContext context)
        {
            _index = context.ShotCount;
            _easeTime = recoilProfile.Duration;
        }


        public void Easing()
        {
            if (_easeTime < 0f) return;

            var rotator = Locator<ICameraRotor>.Instance.Current;

            if (rotator == null) return;

            var pattern = recoilProfile[_index] * scale;

            _easeTime -= Time.deltaTime;

            rotator.HorizontalOffset += pattern.x * Time.deltaTime / recoilProfile.Duration;
            rotator.VerticalOffset += pattern.y * Time.deltaTime / recoilProfile.Duration;
        }
    }
}