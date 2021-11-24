using NebusokuDev.ShooterWeaponSystem.Runtime.Input.Legacy;
using NebusokuDev.ShooterWeaponSystem.Runtime.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Input
{
    public class LegacyWeaponInput : MonoBehaviour, IWeaponInput
    {
        [SerializeField] private InputKeys primaryKeys;
        [SerializeField] private InputKeys primaryAltKeys;
        [SerializeField] private InputKeys secondaryKeys;
        [SerializeField] private InputKeys secondaryAltKeys;
        [SerializeField] private InputKeys reloadKeys;

        public bool IsPrimaryAction => primaryKeys.IsAnyKeyPressed;
        public bool IsPrimaryAltAction => primaryAltKeys.IsAnyKeyPressed;
        public bool IsSecondaryAction => secondaryKeys.IsAnyKeyPressed;
        public bool IsSecondaryAltAction => secondaryAltKeys.IsAnyKeyPressed;
        public bool IsReload => reloadKeys.IsAnyKeyPressed;
    }
}