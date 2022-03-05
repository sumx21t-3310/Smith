using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Extension
{
    public static class GameObjectExtension
    {
        public static void LightSetActive(this GameObject target, bool isActive)
        {
            if (target.activeSelf == isActive) return;

            target.SetActive(isActive);
        }
    }
}