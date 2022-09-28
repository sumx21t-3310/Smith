using System;
using UnityEngine;
using UnityEngine.Events;

namespace NebusokuDev.Smith.Runtime.Domain.AmmoHolder
{
    [Serializable, AddTypeMenu("Standard")]
    public class StandardAmmoHolder : IAmmoHolder
    {
        [SerializeField] private uint remaining = 120;

        public UnityEvent onAmmoEmpty;

        public bool IsEmpty => remaining <= 0;

        public uint Remaining
        {
            get =>remaining;
            set => remaining = value;
        }

        public uint GetAmmo(uint amount)
        {
            if (IsEmpty)
            {
                onAmmoEmpty.Invoke();
                return 0;
            }

            if (remaining < amount)
            {
                var result = remaining;
                remaining = 0;
                return result;
            }

            remaining -= amount;
            return amount;
        }
    }
}