using NebusokuDev.Smith.Runtime.Recoil.RecoilProfile;

namespace NebusokuDev.Smith.Editor.Generator.RecoilGenerateEngine
{
    public interface IRecoilGenerateEngine
    {
        IRecoilVector[] Generate(int length);
    }
}