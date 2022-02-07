using System;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Mover
{
    [Serializable]
    public class CharacterSpeed
    {
        [SerializeField] private float speed = 7f;
        [SerializeField] private float friction = 10f;
        [SerializeField] private float accel = 5f;

        public float Friction => friction;
        public float Accel => accel;
        public float Speed => speed;
    }
}