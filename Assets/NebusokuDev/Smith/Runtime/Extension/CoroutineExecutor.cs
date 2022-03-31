using System.Collections;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Extension
{
    public class CoroutineExecutor : SingletonMonoBehaviour<CoroutineExecutor>
    {
        public Coroutine Execute(IEnumerator coroutine)
        {
            if (coroutine == null) return null;

            return StartCoroutine(coroutine);
        }

        public void Stop(Coroutine coroutine)
        {
            if (coroutine == null) return;

            StopCoroutine(coroutine);
        }
    }
}