using NebusokuDev.Smith.Runtime.Input.Legacy.Button;
using NebusokuDev.Smith.Runtime.ProceduralAnimation.KickbackAnimation;
using NebusokuDev.Smith.Runtime.Sequence.Timer;
using UnityEngine;

namespace NebusokuDev.Smith.Tests.Runtime
{
    public class WeaponTest : MonoBehaviour
    {
        [SerializeField] private InputButtons fireButton = new InputButtons(KeyCode.Mouse0);
        private ProceduralKickbackAnimation _kickbackAnimation;
        [SerializeField] private FixedRpmTimer timer;

        private void Start() => _kickbackAnimation = GetComponent<ProceduralKickbackAnimation>();


        private void Update()
        {
            timer.Update();

            if (timer.IsOverTime && fireButton.IsPressed)
            {
                timer.Lap();
                _kickbackAnimation.Play();
            }
        }
    }
}