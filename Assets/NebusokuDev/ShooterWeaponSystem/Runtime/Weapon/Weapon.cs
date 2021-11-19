using NebusokuDev.ShooterWeaponSystem.Runtime.AmmoHolder;
using NebusokuDev.ShooterWeaponSystem.Runtime.Magazine;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Player;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon;
using NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Weapon
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


        private void Awake() => HandleInjection();

        private void OnEnable() => HandleInjection();

        private void OnDisable() => _playerState = null;


        private void HandleInjection()
        {
            var self = transform;
            _playerState = GetComponentInParent<IPlayerState>();
            _weaponContext ??= new WeaponContext();

            _primary ??= new NoneAction();
            _primary?.Injection(self, _magazine, _weaponContext);

            _secondary ??= new NoneAction();
            _secondary?.Injection(self, _magazine, _weaponContext);

            _input = GetComponent<IWeaponInput>();
        }


        private void Update()
        {
            if (_input == null) return;

            // Use UnityEngine.Object
            if (_playerState == null) _playerState = new RestPlayerState();

            if (_magazine.IsReloading == false && _input.IsReload) StartCoroutine(_magazine.Reload());
            _magazine.AmmoHolder = _ammoHolder;

            _primary?.Action(_input.IsPrimaryAction, _playerState);
            _primary?.AltAction(_input.IsPrimaryAltAction, _playerState);

            _secondary?.Action(_input.IsSecondaryAction, _playerState);
            _secondary?.Action(_input.IsSecondaryAltAction, _playerState);
        }
    }
}