using NebusokuDev.Smith.Runtime.ProceduralAnimation.KickbackAnimation;
using NebusokuDev.Smith.Runtime.Sequence.Timer;
using NebusokuDev.Smith.Samples.StarterKit.Input.Legacy.Button;
using UnityEngine;

namespace NebusokuDev.Smith.Tests.Runtime
{
    public class WeaponTest : MonoBehaviour
    {
        [SerializeField] private InputKeyButton fireKeyButton = new InputKeyButton(KeyCode.Mouse0);
        private ProceduralKickbackAnimation _kickbackAnimation;
        [SerializeField] private FixedRpmTimer timer;

        private void Start() => _kickbackAnimation = GetComponent<ProceduralKickbackAnimation>();


        private void Update()
        {
            timer.Update();

            if (timer.IsOverTime && fireKeyButton.IsPressed)
            {
                timer.Lap();
                _kickbackAnimation.Play();
            }
        }
    }
}