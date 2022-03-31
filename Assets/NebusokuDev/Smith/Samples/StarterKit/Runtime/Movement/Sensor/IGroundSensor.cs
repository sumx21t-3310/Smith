using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.Sensor
{
    public interface IGroundSensor
    {
        public bool IsGrounded(CharacterController controller);
        public Vector3 Normal(CharacterController controller, Vector3 direction);
    }
}