using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.ObjectPool
{
    public class ObjectPoolBinder : MonoBehaviour
    {
        [SerializeReference, SubclassSelector] private IObjectPoolFactory _factory = new DefaultObjectPoolFactory();

        private void Awake() => Locator<IObjectPoolFactory>.Instance.Bind(_factory);
    }
}