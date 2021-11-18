using NebusokuDev.ShooterWeaponSystem.Core.AmmoHolder;
using NebusokuDev.ShooterWeaponSystem.Core.Magazine;
using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using NebusokuDev.ShooterWeaponSystem.Core.WeaponAction;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.Weapon
{
    public class Weapon : MonoBehaviour, IWeapon
    {
        // serializable: 
        [SerializeReference, SubclassSelector] private IWeaponAction _primary = new NoneAction();
        [SerializeReference, SubclassSelector] private IWeaponAction _secondary = new NoneAction();

        [Space(20)] [SerializeReference, SubclassSelector]
        private IMagazine _magazine = new UnlimitedMagazine();

        [Space(20)] [SerializeReference, SubclassSelector]
        private IAmmoHolder _ammoHolder = new UnlimitedAmmoHolder();

        // private:     
        private IWeaponInput _input;
        private IPlayerState _playerState;
        private IWeaponContext _weaponContext;

        // getter
        public IWeaponAction Primary => _primary;
        public IWeaponAction Secondary => _secondary;
        public IMagazine Magazine => _magazine;
        public IAmmoHolder AmmoHolder => _ammoHolder;
        public IWeaponContext Context => _weaponContext;


        private void Awake()
        {
            _weaponContext ??= new WeaponContext();
            
            _primary ??= new NoneAction();
            _primary?.Injection(transform, _magazine, _weaponContext);
            
            _secondary ??= new NoneAction();
            _secondary?.Injection(transform, _magazine, _weaponContext);
            
            _input = GetComponent<IWeaponInput>();
        }


        private void Update()
        {
            if (_playerState == null) return;
            if (_input == null) return;

            if (_magazine.IsReloading == false && _input.IsReload) StartCoroutine(_magazine.Reload());
            _magazine.AmmoHolder = _ammoHolder;

            _primary?.Action(_input.IsPrimaryAction, _playerState);
            _primary?.AltAction(_input.IsPrimaryAltAction, _playerState);
            _secondary?.Action(_input.IsSecondaryAction, _playerState);
            _secondary?.Action(_input.IsSecondaryAltAction, _playerState);
        }


        public void Draw(IPlayerState playerState) { _playerState = playerState; }


        public void Holster(IPlayerState playerState) { _playerState = null; }


        public void PickUp(IPlayerState playerState) { _playerState = playerState; }

        public void Drop(IPlayerState playerState) { _playerState = null; }
    }
}