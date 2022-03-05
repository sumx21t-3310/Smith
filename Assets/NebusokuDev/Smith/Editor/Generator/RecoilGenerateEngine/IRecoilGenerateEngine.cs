using NebusokuDev.Smith.Runtime.Recoil.RecoilProfile;

namespace NebusokuDev.Smith.Editor.Generator.GenerateEngine
{
    public interface IRecoilGenerateEngine
    {
        IRecoilVector[] Generate(int length);
    }
}