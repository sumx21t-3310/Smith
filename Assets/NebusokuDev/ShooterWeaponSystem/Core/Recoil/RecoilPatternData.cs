using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.Recoil
{
    [CreateAssetMenu(fileName = "New Recoil Pattern", menuName = "WeaponSystem/New Recoil Pattern" + "", order = 0)]
    public class RecoilPatternData : ScriptableObject
    {
        [SerializeField] public Vector2[] pattern = new Vector2[35];
        public Vector2 this[int index] => pattern[index % pattern.Length];
    }
}