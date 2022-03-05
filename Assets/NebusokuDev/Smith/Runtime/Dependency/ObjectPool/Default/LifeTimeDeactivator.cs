using System.Collections;
using NebusokuDev.Smith.Runtime.Extension;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Dependency.ObjectPool.Default
{
    public class LifeTimeDeactivator : MonoBehaviour
    {
        [SerializeField] private float duration;
        private WaitForSeconds _seconds;

        private void OnEnable() => StartCoroutine(Deactive());

        IEnumerator Deactive()
        {
            _seconds ??= new WaitForSeconds(duration);
            yield return _seconds;
            gameObject.LightSetActive(false);
        }
    }
}