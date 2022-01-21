using NebusokuDev.Smith;
using NebusokuDev.Smith.Runtime.Animation;
using NebusokuDev.Smith.Runtime.Input.Legacy;
using NebusokuDev.Smith.Runtime.Input.Legacy.Button;
using NebusokuDev.Smith.Runtime.Sequence.Timer;
using UnityEngine;

public class WeaponTest : MonoBehaviour
{
    [SerializeField] private InputButtons fireButton = new InputButtons(KeyCode.Mouse0);
    private ProceduralRecoilAnimation _recoilAnimation;
    [SerializeField] private FixedRpmTimer timer;

    private void Start() => _recoilAnimation = GetComponent<ProceduralRecoilAnimation>();


    private void Update()
    {
        timer.Update();

        if (timer.IsOverTime && fireButton.IsPressed)
        {
            timer.Lap();
            _recoilAnimation.Fire();
        }
    }
}