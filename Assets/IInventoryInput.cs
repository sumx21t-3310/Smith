using UnityEngine.Events;

public interface IInventoryInput
{
    public UnityEvent OnNext { get; }
    public UnityEvent OnReturn { get; }
    public UnityEvent<int> Select { get; }
    public UnityEvent OnStore { get; }
}