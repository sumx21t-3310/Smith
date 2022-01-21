using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input.Legacy.Button
{
    [Serializable]
    public class InputButtons : IInputButton
    {
        [SerializeField] private KeyCode[] keys;

        public InputButtons(params KeyCode[] keyCodes) => keys = keyCodes;

        public bool IsPressed
        {
            get
            {
                foreach (var key in keys)
                {
                    if (UnityEngine.Input.GetKey(key)) return true;
                }

                return false;
            }
        }

        public bool IsPressDown
        {
            get
            {
                foreach (var key in keys)
                {
                    if (UnityEngine.Input.GetKeyDown(key)) return true;
                }

                return false;
            }
        }

        public bool IsPressUp
        {
            get
            {
                foreach (var key in keys)
                {
                    if (UnityEngine.Input.GetKeyUp(key)) return true;
                }

                return false;
            }
        }
    }
}