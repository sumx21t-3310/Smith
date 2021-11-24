using System;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Recoil
{
    [Serializable]
    public class FixedRecoilVector : IRecoilVector
    {
        [SerializeField] private Vector2 value;

        public Vector2 Value
        {
            get => value;
            set => this.value = value;
        }
    }
}