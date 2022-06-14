using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement
{
    public interface IMoverState
    {
        void OnEnter(ref Vector3 moveVelocity, ref Vector3 fallVelocity);
        void OnUpdate(ref Vector3 moveVelocity, ref Vector3 fallVelocity);
        void OnExit(ref Vector3 moveVelocity, ref Vector3 fallVelocity);
    }
}