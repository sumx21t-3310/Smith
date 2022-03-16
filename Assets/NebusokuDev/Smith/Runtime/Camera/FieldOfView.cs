using System;
using UnityEngine;
using static UnityEngine.Mathf;


namespace NebusokuDev.Smith.Runtime.Camera
{
    [Serializable]
    public class FieldOfView
    {
        [SerializeField] private float screenHeight = 1080;
        [SerializeField] private float screenWidth = 1920;
        [SerializeField] private float vertical;

        public float ScreenWidth { get; set; }
        public float ScreenHeight { get; set; }

        public float Vertical
        {
            get => vertical;
            set => vertical = Abs(value);
        }

        public float Horizontal
        {
            get => CalcHorizontalFOV(vertical, Aspect);
            set => vertical = CalcVerticalFOV(value, Aspect);
        }

        private float CalcHorizontalFOV(float verticalFOV, float aspect)
        {
            return Atan(Tan(verticalFOV / 2f * Deg2Rad) * aspect) * 2f * Rad2Deg;
        }

        private float CalcVerticalFOV(float horizontalFOV, float aspect)
        {
            return Atan(Tan(horizontalFOV / 2f * Deg2Rad) / aspect) * 2f * Rad2Deg;
        }

        private float Aspect => screenWidth / screenHeight;
    }
}