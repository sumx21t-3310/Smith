using NebusokuDev.Smith.Runtime.Input.Legacy;
using NebusokuDev.Smith.Runtime.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input
{
    public class LegacyWeaponInput : MonoBehaviour, IWeaponInput
    {
        [SerializeField] private InputButtons primaryButtons = new InputButtons(KeyCode.Mouse0);
        [SerializeField] private InputButtons primaryAltButtons = new InputButtons(KeyCode.B);
        [SerializeField] private InputButtons secondaryButtons = new InputButtons(KeyCode.Mouse1);
        [SerializeField] private InputButtons secondaryAltButtons = new InputButtons(KeyCode.LeftAlt);
        [SerializeField] private InputButtons reloadButtons = new InputButtons(KeyCode.R);

        public bool IsPrimaryAction => primaryButtons.IsPressed;
        public bool IsPrimaryAltAction => primaryAltButtons.IsPressed;
        public bool IsSecondaryAction => secondaryButtons.IsPressed;
        public bool IsSecondaryAltAction => secondaryAltButtons.IsPressed;
        public bool IsReload => reloadButtons.IsPressed;
    }
}