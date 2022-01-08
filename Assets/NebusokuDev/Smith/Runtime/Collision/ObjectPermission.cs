using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Collision
{
    public class ObjectPermission : ObjectPermissionBase
    {
        [SerializeField] private bool selfInteract;
        [SerializeField] private bool selfDamage;
        [SerializeField] private bool selfOwned;

        [SerializeField] private bool teamInteract;
        [SerializeField] private bool teamDamage;
        [SerializeField] private bool teamOwned;

        [SerializeField] private bool enemyInteract;
        [SerializeField] private bool enemyDamage;
        [SerializeField] private bool enemyOwned;

        public override bool SelfInteract => selfInteract;
        public override bool SelfDamage => selfDamage;
        public override bool SelfOwned => selfOwned;

        public override bool TeamInteract => teamInteract;
        public override bool TeamDamage => teamDamage;
        public override bool TeamOwned => teamOwned;

        public override bool EnemyInteract => enemyInteract;
        public override bool EnemyDamage => enemyDamage;
        public override bool EnemyOwned => enemyOwned;
    }
}