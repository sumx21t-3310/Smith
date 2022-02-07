using System;
using NebusokuDev.Smith.Runtime.Recoil.RecoilProfile;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    [Serializable, AddTypeMenu("RecoilSync")]
    public class RecoilSyncMuzzle : IdentityMuzzle
    {
        [SerializeField] private Vector2 scale = Vector2.one;
        [SerializeField] private float resetDuration;
        [SerializeField] private RecoilPatternProfileBase recoilPatternProfile;
        private Vector3 _recoilOffset;

        public override Vector3 Direction => shotPoint.forward + shotPoint.rotation * _recoilOffset;

        public override void Reset()
        {
            _recoilOffset = Vector3.Lerp(_recoilOffset, Vector3.zero, Time.deltaTime / resetDuration);
        }

        public override void Defuse(IPlayerState playerState, IWeaponContext weaponContext)
        {
            base.Defuse(playerState, weaponContext);
            var pattern = recoilPatternProfile[weaponContext.ShotCount];

            _recoilOffset += new Vector3(pattern.x * scale.x, pattern.y * scale.y, 1f) * Mathf.Deg2Rad * Time.deltaTime;
        }
    }
}