using System;
using NebusokuDev.Smith.Runtime.Collision;
using NebusokuDev.Smith.Runtime.Magazine;
using NebusokuDev.Smith.Runtime.Recoil;
using NebusokuDev.Smith.Runtime.Sequence.FireMode;
using NebusokuDev.Smith.Runtime.Sequence.Timer;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet;
using NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle;
using UnityEngine;
using UnityEngine.Events;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack
{
    [Serializable, AddTypeMenu("Attack/Shooting")]
    public class ShootingAction : IWeaponAction
    {
        [SerializeReference, SubclassSelector] protected IRpmTimer Rpm = new FixedRpmTimer();
        [SerializeReference, SubclassSelector] protected IFireMode FireMode = new FullAuto();
        [SerializeField] private uint useAmmoAmount = 1;
        [SerializeReference, SubclassSelector] protected IMuzzle Muzzle = new SpreadMuzzle();
        [SerializeReference, SubclassSelector] protected IRecoil Recoil = new NoneRecoil();
        [SerializeReference, SubclassSelector] protected IBullet Bullet = new HitScanBullet();

        public UnityEvent fire;
        public UnityEvent ammoEmpty;

        protected IObjectPermission Permission;
        protected IObjectGroup ObjectGroup;
        protected IMagazine Magazine;
        protected IWeaponContext WeaponContext;


        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext)
        {
            WeaponContext = weaponContext;
            Permission = parent.GetComponent<IObjectPermission>();
            ObjectGroup = parent.GetComponentInParent<IObjectGroup>();
            Magazine = magazine;
        }


        public void Action(bool isAction, IPlayerState playerState)
        {
            Rpm.Update();
            Recoil?.Easing();

            if (Magazine?.IsReloading ?? false) return;

            if (Rpm.IsOverTime == false) return;

            if (FireMode.Evaluate(isAction) == false)
            {
                WeaponContext.ShotCount = 0;
                Recoil?.Reset();
                Rpm.Reset();

                return;
            }

            if (Magazine?.UseAmmo(useAmmoAmount) == false)
            {
                ammoEmpty.Invoke();
                Recoil?.Reset();

                return;
            }

            Rpm.Lap();
            WeaponContext.ShotCount++;
            Recoil?.Generate(WeaponContext);
            Muzzle.Defuse(playerState, WeaponContext);
            fire.Invoke();
            Fire();
        }


        protected virtual void Fire()
        {
            Bullet?.Shot(Muzzle.Position, Muzzle.Direction, Permission, ObjectGroup);
        }


        public virtual void AltAction(bool isAltAction, IPlayerState playerState) { }

        public virtual void OnHolster() { }


        public virtual void OnDraw() { }
    }
}