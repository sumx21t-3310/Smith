using System;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Aim
{
    [Serializable]
    public class SightSetting
    {
        public float fovMultiple = .9f;
        public Transform referencePoint;
    }
}