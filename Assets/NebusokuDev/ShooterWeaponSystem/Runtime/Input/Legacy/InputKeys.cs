using System;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Input.Legacy
{
    [Serializable]
    public class InputKeys
    {
        [SerializeField] private KeyCode[] keys;

        public InputKeys(params KeyCode[] keyCodes) => keys = keyCodes;

        public bool IsAnyKeyPressed
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

        public bool IsAnyKeyDown
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

        public bool IsAnyKeyUp
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