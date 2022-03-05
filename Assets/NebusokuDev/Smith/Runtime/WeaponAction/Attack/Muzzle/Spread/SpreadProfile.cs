using NebusokuDev.Smith.Runtime.State.Player;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle.Spread
{
    [CreateAssetMenu(menuName = "Smith/SpreadProfile")]
    public class SpreadProfile : SpreadProfileBase
    {
        [SerializeReference, SubclassSelector] private ISpread[] _spreads;

        public override ISpread this[PlayerMovementContext context]
        {
            get
            {
                foreach (var spread in _spreads)
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