using System;
using NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Attack.ShotgunDefuse;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Attack
{
    [Serializable, AddTypeMenu("Attack/ShotgunShooting")]

    public class ShotgunShootingAction : ShootingAction
    {
        [SerializeField] private ShotgunDefuseBase shotgunDefuse;


        protected override void Fire()
        {
            foreach (var offset in shotgunDefuse)
            {
                var muzzleOffset = muzzle.Rotation * offset;
                bullet.Shot(muzzle.Position, muzzle.Direction + muzzleOffset, permission, objectGroup);
            }
        }
    }
}