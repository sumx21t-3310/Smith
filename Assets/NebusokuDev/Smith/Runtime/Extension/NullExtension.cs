namespace NebusokuDev.Smith.Runtime.Util
{
    public static class NullExtension
    {
        public static T NCast<T>(this T target) where T : UnityEngine.Object => target != null ? target : null;
    }
}