using NebusokuDev.Smith.Runtime.State.Player;
using UnityEngine;

namespace NebusokuDev.Smith
{
    public class PlayerStateDebugger : MonoBehaviour
    {
        private IPlayerState _state;

        private void Start()
        {
            _state = GetComponent<IPlayerState>();
        }


        // Update is called once per frame
        void Update()
        {
            if (_state == null) 
            {
                Debug.LogWarning("player state not attached");
                
                return;
            }
            Debug.Log($"State: {_state.Context.ToString()}");
        }
    }
}