using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float dumpTime = .1f;


    private Transform _self;
    private Quaternion _defaultRotate;

    private Vector3 _savedPosition;

    private void Awake()
    {
        _self = transform;
        _defaultRotate = _self.localRotation;
    }

    private void Update()
    {
        offset += target.position - _savedPosition;

        if (offset.sqrMagnitude < 0.001f)
        {
            offset = Vector3.zero;
        }

        offset = Vector3.Slerp(offset, Vector3.zero, Time.deltaTime / dumpTime);


        _savedPosition = target.position;


        _self.localRotation = Quaternion.LookRotation(_defaultRotate * Vector3.forward + offset);
    }
}