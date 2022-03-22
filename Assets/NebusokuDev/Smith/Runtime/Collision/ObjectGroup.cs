using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Collision
{
    public class ObjectGroup : MonoBehaviour, IObjectGroup
    {
        [SerializeField] private int groupId;
        [SerializeField] private int selfId;
        public int SelfId => selfId;
        public int GroupId => groupId;

        public override string ToString() => $"selfId: {selfId.ToString()}, groupId: {groupId.ToString()}";
    }
}