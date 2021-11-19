using System;
using NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.ShotgunDefuse;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack
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