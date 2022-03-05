using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.Input.Legacy;

namespace NebusokuDev.Smith.Runtime.Input
{
    public class LegacyMouseSensitivity : Sensitivity<LegacyMouseCameraInput>
    {
        private void Awake() => Locator<LegacyMouseSensitivity>.Instance.Bind(this);
    }
}