namespace NebusokuDev.Smith.Runtime.Collision
{
    public interface IObjectIdentity
    {
        int SelfId { get; }
        int TeamId { get; }
    }
}