using NebusokuDev.ShooterWeaponSystem.Runtime.Input.Legacy;
using NebusokuDev.ShooterWeaponSystem.Runtime.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Input
{
    public class LegacyWeaponInput : MonoBehaviour, IWeaponInput
    {
        [SerializeField] private InputButtons primaryButtons;
        [SerializeField] private InputButtons primaryAltButtons;
        [SerializeField] private InputButtons secondaryButtons;
        [SerializeField] private InputButtons secondaryAltButtons;
        [SerializeField] private InputButtons reloadButtons;

        public bool IsPrimaryAction => primaryButtons.IsPressed;
        public bool IsPrimaryAltAction => primaryAltButtons.IsPressed;
        public bool IsSecondaryAction => secondaryButtons.IsPressed;
        public bool IsSecondaryAltAction => secondaryAltButtons.IsPressed;
        public bool IsReload => reloadButtons.IsPressed;
    }
}