using NebusokuDev.Smith.Runtime.AmmoHolder;
using NebusokuDev.Smith.Runtime.Collision;
using NebusokuDev.Smith.Runtime.Magazine;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using NebusokuDev.Smith.Runtime.WeaponAction;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Weapon
{
    [RequireComponent(typeof(IObjectPermission))]
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

        public void Draw()
        {
            _primary?.OnDraw();
            _secondary?.OnDraw();
            StopCoroutine(ReloadCoroutine);
        }

        public void Holster()
        {
            StopCoroutine(ReloadCoroutine);
            _primary?.OnHolster();
            _secondary?.OnHolster();
        }

        public Coroutine ReloadCoroutine { get; private set; }


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

            if (TryGetComponent(out _input) == false) _input = GetComponentInParent<IWeaponInput>();
        }


        private void Update()
        {
            if (_input == null) return;

            // Use UnityEngine.Object
            _playerState ??= new RestPlayerState();

            if (_magazine.IsReloading == false && _input.IsReload)
            {
                ReloadCoroutine = StartCoroutine(_magazine.ReloadCoroutine());
            }

            _magazine.AmmoHolder = _ammoHolder;

            if (_magazine.IsReloading) return;

            _primary?.Action(_input.IsPrimaryAction && _magazine.IsReloading == false, _playerState);
            _primary?.AltAction(_input.IsPrimaryAltAction && _magazine.IsReloading == false, _playerState);

            _secondary?.Action(_input.IsSecondaryAction && _magazine.IsReloading == false, _playerState);
            _secondary?.AltAction(_input.IsSecondaryAltAction && _magazine.IsReloading == false, _playerState);
        }
    }
}