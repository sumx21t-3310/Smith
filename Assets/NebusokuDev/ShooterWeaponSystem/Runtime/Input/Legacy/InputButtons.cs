using System;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Input.Legacy
{
    [Serializable]
    public class InputKeys : IInputButton
    {
        [SerializeField] private KeyCode[] keys;

        public InputKeys(params KeyCode[] keyCodes) => keys = keyCodes;

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