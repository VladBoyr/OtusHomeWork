using UnityEngine;
using Version2.WeaponSystem;

namespace Version2.Player
{
    public sealed class PlayerController
    {
        private readonly IInputService _inputService;
        private readonly PlayerFacade _playerFacade;
        private readonly WeaponService _weaponService;
        private readonly BulletConfig _bulletConfig;

        public PlayerController(
            IInputService input,
            PlayerFacade player,
            WeaponService weaponService,
            BulletConfig config)
        {
            this._inputService = input;
            this._playerFacade = player;
            this._weaponService = weaponService;
            this._bulletConfig = config;
        }

        public void Enable()
        {
            this._inputService.OnFire += this.OnFire;
        }

        public void Disable()
        {
            this._inputService.OnFire -= this.OnFire;
        }

        public void OnFixedUpdate()
        {
            var moveDirection = this._inputService.MoveDirection;
            if (moveDirection != Vector2.zero)
            {
                this._playerFacade.Move(moveDirection * Time.fixedDeltaTime);
            }
        }

        private void OnFire()
        {
            this._weaponService.Fire(this._playerFacade.Weapon, this._bulletConfig, Vector2.up);
        }
    }
}