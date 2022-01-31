using System;
using NebusokuDev.Smith.Runtime.Recoil.RecoilProfile;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    [Serializable]
    public class JumpUpMuzzle : SpreadMuzzle
    {
        [SerializeField] private float power;
        [SerializeField] private float resetDuration;
        [SerializeField] private RecoilPatternProfileBase _recoilPatternProfileBase;
        private Vector3 _offset;

        public override Vector3 Direction => shotPoint.forward + _offset;

        public override void Reset()
        {
            _offset = Vector3.Lerp(_offset, Vector3.zero, Time.deltaTime / resetDuration);
        }

        public override void Defuse(IPlayerState playerState, IWeaponContext weaponContext)
        {
            base.Defuse(playerState, weaponContext);
            _offset += Vector3.up * Mathf.Deg2Rad * power * Time.deltaTime;
        }
    }
}