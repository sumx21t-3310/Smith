using UnityEngine;

namespace NebusokuDev.Smith.Experimental
{
    public class WeaponBobbing : MonoBehaviour
    {
        [SerializeField] private Vector2 scale = Vector2.one * .1f;
        [SerializeField] private float cycle = .5f;
        [SerializeField] private AnimationCurve curve;

        private Vector3 _defaultPosition;
        private Vector3 _offset;

        private void Awake()
        {
            _defaultPosition = transform.localPosition;
        }


        // Update is called once per frame
        void Update()
        {
            var phase = Time.time / cycle;

            var y = curve.Evaluate(phase % 1f);


            _offset = new Vector3(0f, y);

            transform.localPosition = _defaultPosition + _offset;
        }
    }
}