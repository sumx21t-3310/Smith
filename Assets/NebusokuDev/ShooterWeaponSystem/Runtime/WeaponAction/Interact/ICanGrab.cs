using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Interact
{
    public interface ICanGrab
    {
        void Grab(Vector3 position, Vector3 forward);
    }
}