using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Input.Legacy.Button
{
    [Serializable]
    public class InputButtons : IInputButton
    {
        [SerializeReference, SubclassSelector] private List<IInputButton> _buttons = new List<IInputButton>();


        public bool IsPressDown
        {
            get
            {
                if (_buttons.Any() == false) return false;

                foreach (var inputButton in _buttons)
                {
                    if (inputButton.IsPressDown) return true;
                }

                return false;
            }
        }

        public bool IsPressUp
        {
            get
            {
                if (_buttons.Any() == false) return false;

                foreach (var inputButton in _buttons)
                {
                    if (inputButton.IsPressUp) return true;
                }

                return false;
            }
        }

        public bool IsPressed
        {
            get
            {
                if (_buttons.Any() == false) return false;

                foreach (var inputButton in _buttons)
                {
                    if (inputButton.IsPressed) return true;
                }

                return false;
            }
        }
    }
}