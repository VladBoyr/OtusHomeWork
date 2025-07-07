using UnityEngine;
using WeaponSystem;

namespace Player
{
    public sealed class PlayerController
    {
        private readonly IInputService _inputService;
        private readonly PlayerFacade _playerFacade;
        private readonly WeaponService _weaponService;

        public PlayerController(
            IInputService input,
            PlayerFacade player,
            WeaponService weaponService)
        {
            this._inputService = input;
            this._playerFacade = player;
            this._weaponService = weaponService;
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
            this._weaponService.Fire(this._playerFacade.Weapon, Vector2.up);
        }
    }
}