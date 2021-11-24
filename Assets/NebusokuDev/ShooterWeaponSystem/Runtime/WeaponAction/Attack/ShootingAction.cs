using System;
using NebusokuDev.ShooterWeaponSystem.Runtime.Collision;
using NebusokuDev.ShooterWeaponSystem.Runtime.Magazine;
using NebusokuDev.ShooterWeaponSystem.Runtime.Recoil;
using NebusokuDev.ShooterWeaponSystem.Runtime.Sequence.FireMode;
using NebusokuDev.ShooterWeaponSystem.Runtime.Sequence.Timer;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Player;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon;
using NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.Bullet;
using NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.Muzzle;
using UnityEngine;
using UnityEngine.Events;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack
{
    [Serializable, AddTypeMenu("Attack/Shooting")]
    public class ShootingAction : IWeaponAction
    {
        [SerializeReference, SubclassSelector] protected IRpmTimer rpm = new FixedRpmTimer();
        [SerializeReference, SubclassSelector] protected IFireMode fireMode = new FullAuto();
        [SerializeField] private uint useAmmoAmount = 1;
        [SerializeReference, SubclassSelector] protected IMuzzle muzzle = new SpreadMuzzle();
        [SerializeReference, SubclassSelector] protected IRecoil recoil = new NoneRecoil();
        [SerializeReference, SubclassSelector] protected IBullet bullet = new HitScanBullet();

        public UnityEvent fire;
        public UnityEvent ammoEmpty;

        protected IObjectPermission permission;
        protected IObjectGroup objectGroup;
        protected IMagazine magazine;
        protected IWeaponContext weaponContext;


        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext)
        {
            this.weaponContext = weaponContext;
            permission = parent.GetComponent<IObjectPermission>();
            objectGroup = parent.GetComponentInParent<IObjectGroup>();
            this.magazine = magazine;
        }


        public void Action(bool isAction, IPlayerState playerState)
        {
            rpm.Update();
            recoil?.Easing();

            if (magazine?.IsReloading ?? false) return;

            if (rpm.IsOverTime == false) return;

            if (fireMode.Evaluate(isAction) == false)
            {
                weaponContext.ShotCount = 0;
                recoil?.Reset();
                rpm.Reset();

                return;
            }

            if (magazine?.UseAmmo(useAmmoAmount) == false)
            {
                ammoEmpty.Invoke();
                recoil?.Reset();

                return;
            }

            rpm.Lap();
            weaponContext.ShotCount++;
            recoil?.Generate(weaponContext);
            muzzle.Defuse(playerState, weaponContext);
            fire.Invoke();
            Fire();
        }


        protected virtual void Fire()
        {
            bullet?.Shot(muzzle.Position, muzzle.Direction, permission, objectGroup);
        }


        public virtual void AltAction(bool isAltAction, IPlayerState playerState) { }

        public virtual void OnHolster() { }


        public virtual void OnDraw() { }
    }
}