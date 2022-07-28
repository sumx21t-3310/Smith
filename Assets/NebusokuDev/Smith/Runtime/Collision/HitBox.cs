using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Collision
{
    [RequireComponent(typeof(Collider))]
    public class HitBox : MonoBehaviour, IHitBox
    {
        [SerializeField] private BodyType bodyType;
        private IHasHitPoint _hasHitPoint;
        private IObjectIdentity _objectIdentity;
        public BodyType BodyType => bodyType;
        public IObjectIdentity ObjectIdentity => _objectIdentity;


        private void Awake()
        {
            _hasHitPoint = transform.GetComponentInParent<IHasHitPoint>();
            _objectIdentity = transform.GetComponentInParent<IObjectIdentity>();
        }

        public void AddDamage(float damage) => _hasHitPoint.AddDamage(damage);
    }
}