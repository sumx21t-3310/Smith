using NebusokuDev.Smith.Runtime.Collision;
using NebusokuDev.Smith.Runtime.Domain.AmmoHolder;
using NebusokuDev.Smith.Runtime.Domain.Magazine;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using NebusokuDev.Smith.Runtime.WeaponAction;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Weapon
{
    [RequireComponent(typeof(IObjectPermission))]
    public class Weapon : MonoBehaviour, IWeapon
    {
        [SerializeReference, SubclassSelector] private IWeaponAction _primary = new NoneAction();
        [SerializeReference, SubclassSelector] private IWeaponAction _secondary = new NoneAction();

        [Space(20)] [SerializeReference, SubclassSelector]
        private IMagazine _magazine = new UnlimitedMagazine();

        [Space(20)] [SerializeReference, SubclassSelector]
        private IAmmoHolder _ammoHolder = new UnlimitedAmmoHolder();


        private IWeaponInput _input;
        private IPlayerState _playerState;
        private IWeaponContext _weaponContext;


        // getter
        public IWeaponAction Primary => _primary;
        public IWeaponAction Secondary => _secondary;
        public IMagazine Magazine => _magazine;
        public IAmmoHolder AmmoHolder => _ammoHolder;
        public IWeaponContext Context => _weaponContext;

        public void Draw()
        {
            _primary?.OnDraw();
            _secondary?.OnDraw();
            _magazine?.ReloadCancel();
        }

        public void Holster()
        {
            _primary?.OnHolster();
            _secondary?.OnHolster();
            _magazine?.ReloadCancel();
        }


        private void Awake() => HandleInjection();

        private void OnEnable() => HandleInjection();


        private void OnDisable()
        {
            _playerState = null;
            _magazine?.ReloadCancel();
            _primary?.OnHolster();
            _secondary?.OnHolster();
        }


        private void HandleInjection()
        {
            var self = transform;
            _playerState = GetPlayerState();
            _weaponContext ??= new WeaponContext();

            _primary ??= new NoneAction();
            _primary?.Injection(self, _magazine, _weaponContext);

            _secondary ??= new NoneAction();
            _secondary?.Injection(self, _magazine, _weaponContext);

            _input = GetInput();
        }

        protected virtual IWeaponInput GetInput() => GetComponentInParent<IWeaponInput>();

        protected virtual IPlayerState GetPlayerState() => GetComponentInParent<IPlayerState>();

        private void Update()
        {
            if (_input == null) return;

            // Use UnityEngine.Object
            _playerState ??= new RestPlayerState();

            if (_magazine.IsReloading == false && _input.IsReload)
            {
                _magazine.Reload();
            }

            _magazine.AmmoHolder = _ammoHolder;


            _primary?.Action(_input.IsPrimaryAction && _magazine.IsReloading == false, _playerState);
            _primary?.AltAction(_input.IsPrimaryAltAction && _magazine.IsReloading == false, _playerState);

            _secondary?.Action(_input.IsSecondaryAction && _magazine.IsReloading == false, _playerState);
            _secondary?.AltAction(_input.IsSecondaryAltAction && _magazine.IsReloading == false, _playerState);
        }
    }
}