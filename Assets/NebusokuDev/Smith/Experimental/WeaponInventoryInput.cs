using NebusokuDev.Smith.Runtime.Input.Legacy.Button;
using UnityEngine;

namespace NebusokuDev.Smith.Experimental
{
    public class WeaponInventoryInput : MonoBehaviour
    {
        [SerializeReference, SubclassSelector] private IInputButton changeButton = new InputKeyButton(KeyCode.Alpha1);
        [SerializeReference, SubclassSelector] private IInputButton holsterButtun = new InputKeyButton(KeyCode.Alpha3);
        public bool IsChange => changeButton.IsPressDown;

        public bool IsHolster => holsterButtun.IsPressDown;
    }
}