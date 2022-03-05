using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Movement
{
    [RequireComponent(typeof(Movement.Mover))]
    public class ObjectPusher : MonoBehaviour
    {
        private Movement.Mover _mover;

        private void Start() => _mover = GetComponent<Movement.Mover>();


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