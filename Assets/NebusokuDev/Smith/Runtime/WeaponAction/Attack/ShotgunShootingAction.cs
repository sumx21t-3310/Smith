using System;
using NebusokuDev.Smith.Runtime.WeaponAction.Attack.ShotgunDefuse;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack
{
    [Serializable, AddTypeMenu("Attack/ShotgunShooting")]

    public class ShotgunShootingAction : ShootingAction
    {
        [SerializeField] private ShotgunDefuseBase shotgunDefuse;


        protected override void Fire()
        {
            foreach (var offset in shotgunDefuse)
            {
                var muzzleOffset = Muzzle.Rotation * offset;
                Bullet.Shot(Muzzle.Position, Muzzle.Direction + muzzleOffset, Permission, ObjectGroup);
            }
        }
    }
}