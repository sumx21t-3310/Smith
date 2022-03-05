using System.Collections.Generic;
using System.Linq;
using NebusokuDev.Smith.Runtime.Extension;
using UnityEngine;

namespace NebusokuDev.Smith.Experimental
{
    public class WeaponInventory : MonoBehaviour
    {
        private List<Transform> _items;
        private WeaponInventoryInput _input;
        private int _index;

        private void Awake()
        {
            _items ??= new List<Transform>();
            _input = GetComponent<WeaponInventoryInput>();
            _items.AddRange(transform.OfType<Transform>());
            ChangeWeapon(0);
        }

        private void Update()
        {
            if (_input.IsChange)
            {
                _index++;
                _index %= _items.Count;
                ChangeWeapon(_index);
            }

            if (_input.IsHolster)
            {
                Holster();
            }
        }

        private void Holster()
        {
            foreach (var item in _items)
            {
                item.gameObject.LightSetActive(false);
            }
        }

        private void ChangeWeapon(int index)
        {
            if (_items.Any() == false) return;

            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].gameObject.LightSetActive(i == index);
            }
        }
    }
}