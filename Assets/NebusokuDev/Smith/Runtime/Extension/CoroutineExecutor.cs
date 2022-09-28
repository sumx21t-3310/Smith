using System.Collections;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Extension
{
    public class CoroutineExecutor : SingletonMonoBehaviour<CoroutineExecutor>
    {
        public Coroutine Execute(IEnumerator coroutine)
        {
            return coroutine != null ? StartCoroutine(coroutine) : null;
        }

        public void Stop(Coroutine coroutine)
        {
            if (coroutine == null) return;

            StopCoroutine(coroutine);
        }
    }
}