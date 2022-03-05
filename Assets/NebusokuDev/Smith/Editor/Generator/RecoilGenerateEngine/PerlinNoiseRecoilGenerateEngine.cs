using System.Collections.Generic;
using NebusokuDev.Smith.Runtime.Recoil.RecoilProfile;

namespace NebusokuDev.Smith.Editor.Generator.GenerateEngine
{
    public class PerlinNoiseRecoilGenerateEngine : IRecoilGenerateEngine
    {
        public IRecoilVector[] Generate(int length)
        {
            var recoils = new List<IRecoilVector>();
            return recoils.ToArray();
        }
    }
}