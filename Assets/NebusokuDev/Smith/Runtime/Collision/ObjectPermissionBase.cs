using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Collision
{
    public abstract class ObjectPermissionBase : MonoBehaviour, IObjectPermission
    {
        public abstract bool SelfInteract { get; }
        public abstract bool SelfDamage { get; }
        public abstract bool SelfOwned { get; }
        public abstract bool TeamInteract { get; }
        public abstract bool TeamDamage { get; }
        public abstract bool TeamOwned { get; }
        public abstract bool EnemyInteract { get; }
        public abstract bool EnemyDamage { get; }
        public abstract bool EnemyOwned { get; }
    }
}