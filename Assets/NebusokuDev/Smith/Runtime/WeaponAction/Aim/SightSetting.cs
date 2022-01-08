using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Aim
{
    [Serializable]
    public class SightSetting
    {
        public float fovMultiple = .9f;
        public Transform referencePoint;
    }
}