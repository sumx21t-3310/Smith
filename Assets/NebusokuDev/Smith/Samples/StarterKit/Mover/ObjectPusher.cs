using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Mover
{
    [RequireComponent(typeof(Mover))]
    public class ObjectPusher : MonoBehaviour
    {
        private Mover _mover;

        private void Start() => _mover = GetComponent<Mover>();


        private void OnControllerColliderHit(ControllerColliderHit  collision)
        {
            if (collision.transform.TryGetComponent(out Rigidbody target))
            {
                Debug.Log("Push!");
                var onPlaneVelocity = Vector3.ProjectOnPlane(_mover.Velocity, Vector3.up);
                target.AddForce(onPlaneVelocity, ForceMode.VelocityChange);
            }
        }
    }
}