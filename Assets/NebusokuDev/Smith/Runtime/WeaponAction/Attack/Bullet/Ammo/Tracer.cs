using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet.Ammo
{
    public class Tracer : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float smoothTime = .01f; 
        public void SetPosition(Vector3 start, Vector3 end)
        {
            transform.position = start;
            _end = end;
        }

        private Vector3 _end;
        private Vector3 _vel;

        private void FixedUpdate()
        {
            transform.position = Vector3.SmoothDamp(transform.position, _end, ref _vel, smoothTime, speed, Time.deltaTime);
        }
    }
}