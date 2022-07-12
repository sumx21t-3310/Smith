using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Collision
{
    public class LocalObjectIdentity : MonoBehaviour, IObjectIdentity
    {
        [SerializeField] private int teamId;

        private int? _selfId;
        
        public int SelfId => _selfId ??= GetInstanceID();
        public int TeamId => teamId;

        public override string ToString() => $"selfId: {SelfId.ToString()}, groupId: {SelfId.ToString()}";
    }
}    