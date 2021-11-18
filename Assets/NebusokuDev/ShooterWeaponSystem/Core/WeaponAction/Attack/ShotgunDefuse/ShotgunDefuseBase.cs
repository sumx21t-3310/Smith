using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Attack.ShotgunDefuse
{
    public abstract class ShotgunDefuseBase :ScriptableObject , IEnumerable<Vector3>
    {
        public abstract IEnumerator<Vector3> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}