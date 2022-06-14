using System;
using NebusokuDev.Smith.Runtime.Collision;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet.DamageValidator
{
    [Serializable, AddTypeMenu("Default")]
    public class DefaultDamageValidator : IDamageValidator
    {
        [SerializeField] private bool isIgnorePermission;
        public event Action OnSelfHit;
        public event Action OnTeamHit;
        public event Action OnEnemyHit;


        public bool ValidateDamage(IObjectIdentity owner, IObjectIdentity target, IObjectPermission permission)
        {
            if (isIgnorePermission) return true;

            if (owner.SelfId == target.SelfId)
            {
                OnSelfHit?.Invoke();

                return permission.SelfDamage;
            }

            if (owner.TeamId == target.TeamId)
            {
                OnTeamHit?.Invoke();

                return permission.TeamDamage;
            }

            OnEnemyHit?.Invoke();
            return permission.EnemyDamage;
        }
    }
}