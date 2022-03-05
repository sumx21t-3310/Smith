using System;
using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.Input.Legacy;

namespace NebusokuDev.Smith.Runtime.Input
{
    public class MouseSensitivity : Sensitivity<LegacyMouseCameraInput>
    {
        private void Awake()
        {
            Locator<MouseSensitivity>.Instance.Current
        }
    }
}