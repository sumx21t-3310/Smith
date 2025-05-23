﻿using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime
{
    public class CursorSetter : MonoBehaviour
    {
        private void OnEnable() => Cursor.lockState = CursorLockMode.Locked;


        private void OnDisable() => Cursor.lockState = CursorLockMode.None;
    }
}