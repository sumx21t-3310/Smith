using NebusokuDev.Smith.Runtime.Input.Legacy;
using NebusokuDev.Smith.Runtime.Input.Legacy.Button;
using NebusokuDev.Smith.Runtime.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input
{
    public class LegacyWeaponInput : MonoBehaviour, IWeaponInput
    {
        [SerializeField] private InputKeyButton primaryKeyButton = new InputKeyButton(KeyCode.Mouse0);
        [SerializeField] private InputKeyButton primaryAltKeyButton = new InputKeyButton(KeyCode.B);
        [SerializeField] private InputKeyButton secondaryKeyButton = new InputKeyButton(KeyCode.Mouse1);
        [SerializeField] private InputKeyButton secondaryAltKeyButton = new InputKeyButton(KeyCode.LeftAlt);
        [SerializeField] private InputKeyButton reloadKeyButton = new InputKeyButton(KeyCode.R);

        public bool IsPrimaryAction => primaryKeyButton.IsPressed;
        public bool IsPrimaryAltAction => primaryAltKeyButton.IsPressed;
        public bool IsSecondaryAction => secondaryKeyButton.IsPressed;
        public bool IsSecondaryAltAction => secondaryAltKeyButton.IsPressed;
        public bool IsReload => reloadKeyButton.IsPressed;
    }
}