using System;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Input.Legacy.Button
{
    [Serializable]
    public class InputKeyButton : IInputButton
    {
        [SerializeField] private KeyCode[] keys;

        public InputKeyButton() => keys = new KeyCode[] { };


        public InputKeyButton(params KeyCode[] keyCodes) => keys = keyCodes;

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