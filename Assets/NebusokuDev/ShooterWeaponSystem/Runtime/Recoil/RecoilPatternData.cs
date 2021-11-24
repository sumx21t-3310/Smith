using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Recoil
{
    [CreateAssetMenu(fileName = "New Recoil Pattern", menuName = "WeaponSystem/New Recoil Pattern" + "", order = 0)]
    public class RecoilPatternData : ScriptableObject
    {
        [SerializeReference, SubclassSelector] public IRecoilVector[] pattern;
        public Vector2 this[int index] => pattern[index % pattern.Length].Value;
    }
}