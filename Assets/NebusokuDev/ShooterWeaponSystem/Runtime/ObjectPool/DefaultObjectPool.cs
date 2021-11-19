using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Object;

namespace NebusokuDev.ShooterWeaponSystem.Runtime.ObjectPool
{
    public class DefaultObjectPool<TComponent> : IObjectPool<TComponent> where TComponent : Component
    {
        private TComponent _prefab;
        private List<TComponent> _observePrefab;
        private int _maxPooling;
        private int _lastPoped;

        public DefaultObjectPool(TComponent prefab, int preInstantiate = 10)
        {
            _prefab = prefab;
            _observePrefab = new List<TComponent>(preInstantiate) {_prefab};

            foreach (var _ in Enumerable.Range(0, preInstantiate))
            {
                var add = Instantiate(_prefab);
                add.gameObject.SetActive(false);
                _observePrefab.Add(add);
            }
        }

        public int MaxPooling
        {
            get => _maxPooling;
            set => _maxPooling = value;
        }

        public TComponent GetObject()
        {
            for (int i = 0; i < _observePrefab.Count; i++)
            {
                if (_observePrefab[i].gameObject.activeSelf == false)
                {
                    _lastPoped = i;
                    return _observePrefab[i];
                }
            }

            if (_maxPooling < PlayingCount && _maxPooling > 0)
            {
                _observePrefab[(_lastPoped + 3) % _observePrefab.Count].gameObject.SetActive(false);
                return _observePrefab[(_lastPoped + 3) % _observePrefab.Count];
            }


            var added = Instantiate(_prefab);
            _observePrefab.Add(added);
            return added;
        }


        public int PlayingCount => _observePrefab.Count(component => component.gameObject.activeSelf);

        public void Sleep()
        {
            foreach (var component in _observePrefab) component.gameObject.SetActive(false);
        }

        public void Clear()
        {
            foreach (var component in _observePrefab) Destroy(component);
            _observePrefab.Clear();
        }

    }
}