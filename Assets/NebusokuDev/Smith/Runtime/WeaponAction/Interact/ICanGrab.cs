using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Interact
{
    public interface ICanGrab
    {
        void Grab(Vector3 position, Vector3 forward);
    }
}