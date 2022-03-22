using System;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Movement
{
    [Serializable]
    public class CharacterHeight
    {
        [SerializeField] private float crouchHeight = 1.2f;
        [SerializeField] private float standHeight = 2f;
        [SerializeField] private float switchTime = 0.05f;

        public float CalcHeight(float current, bool isCrouch)
        {
            var toHeight = isCrouch ? crouchHeight : standHeight;
            return Mathf.SmoothStep(current, toHeight, Time.deltaTime / switchTime);
        }
    }
}