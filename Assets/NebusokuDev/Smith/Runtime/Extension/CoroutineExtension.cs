using System.Collections;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Extension
{
    public static class CoroutineExtension
    {
        public static Coroutine Start(this IEnumerator routine)
        {
            return CoroutineExecutor.Instance.Execute(routine);
        }

        public static void Start(this  Coroutine coroutine, IEnumerator enumerator)
        {
            coroutine = enumerator.Start();
        }

        public static void Stop(this Coroutine coroutine)
        {
            CoroutineExecutor.Instance.Stop(coroutine);
        }
    }
}