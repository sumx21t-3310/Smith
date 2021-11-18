using NebusokuDev.ShooterWeaponSystem.Core.Magazine;
using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction
{
    public interface IWeaponAction
    {
        /// <summary>
        /// 依存するオブジェクトを注入するためのメソッドです
        /// 独自にWeaponActionクラスを作成するときはAwake()でコールしてください
        /// <param name="parent"></param>
        /// <param name="magazine"></param>
        /// <param name="weaponContext"></param>
        /// </summary>
        void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext);


        /// <summary>
        /// 動作の核になるアクションです
        /// 希望する動作を実装してください
        /// </summary>
        /// <param name="isAction"></param>
        /// <param name="playerState"></param>
        void Action(bool isAction, IPlayerState playerState);


        /// <summary>
        /// オプションを設定するアクションです。
        /// </summary>
        /// <param name="isAltAction"></param>
        /// <param name="playerState"></param>
        void AltAction(bool isAltAction, IPlayerState playerState);


        void OnHolster();

        void OnDraw();
    }
}