using NebusokuDev.Smith.Runtime.State.Player;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    [CreateAssetMenu(menuName = "WeaponSystem/SpreadProfile")]
    public class SpreadProfile : SpreadProfileBase
    {
        [SerializeReference, SubclassSelector] private ISpread[] spreads = new RandomSpread[5];

        public override ISpread this[PlayerMovementContext context]
        {
            get
            {
                foreach (var spread in spreads)
                {
                    if (spread.Context == context) return spread;
                }

#if UNITY_EDITOR
                Debug.Log("Spread: undefined...");
#endif

                return RandomSpread.Default;
            }
        }
    }
}