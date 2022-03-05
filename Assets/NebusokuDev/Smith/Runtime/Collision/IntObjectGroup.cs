using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Collision
{
    public class ObjectGroup<ISelfId, TGroupId> : MonoBehaviour, IObjectGroup<ISelfId, TGroupId>
    {
        [SerializeField] private int groupId;

        private Guid? _selfId;

        public Guid SelfId => _selfId ??= Guid.NewGuid();

        public int GroupId => groupId;

        public override string ToString() => $"selfId: {_selfId.ToString()}, groupId: {groupId.ToString()}";
    }
}