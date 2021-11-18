using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Interact
{
    public interface ICanGrab
    {
        void Grab(Vector3 position, Vector3 forward);
    }
}