using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Toolkit
{
    public class CameraRotateHeightSetter : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private new Collider collider;
        private Transform _transform;

        private void Awake() => _transform = transform;

        private void LateUpdate()
        {
            switch (collider)
            {
                case BoxCollider box:
                    _transform.localPosition = box.center + new Vector3(0f, box.size.y / 2f) + offset;
                    return;

                case CapsuleCollider capsule:
                    _transform.localPosition =
                        capsule.center + new Vector3(0f, capsule.height / 2f + capsule.radius) + offset;
                    return;

                case CharacterController character:
                    _transform.localPosition = character.center +
                                               new Vector3(0f, character.height / 2f + -character.radius) + offset;
                    return;

                default: return;
            }
        }
    }
}