using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Collision
{
    [RequireComponent(typeof(Collider))]
    public class HitBoxBase<ISelfId, TGroupId> : MonoBehaviour, IHitBox
    {
        [SerializeField] private BodyType bodyType;
        private IHasHitPoint _hasHitPoint;
        private IObjectGroup<ISelfId, TGroupId> _group;
        public BodyType BodyType => bodyType;
        public IObjectGroup<ISelfId, TGroupId> ObjectGroup => _group;

        private void Awake()
        {
            _hasHitPoint = transform.GetComponentInParent<IHasHitPoint>();
            _group = transform.GetComponentInParent<IObjectGroup<ISelfId, TGroupId>>();
        }

        public void AddDamage(float damage) => _hasHitPoint.AddDamage(damage);
    }
}