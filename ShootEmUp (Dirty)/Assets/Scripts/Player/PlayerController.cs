using Core;
using UnityEngine;
using Weapons;

namespace Player
{
    public sealed class PlayerController
    {
        private readonly PlayerUnit _player;
        private readonly IInputService _inputService;
        private readonly WeaponService _weaponService;

        public PlayerController(
            PlayerUnit player,
            IInputService input,
            WeaponService weaponService)
        {
            this._player = player;
            this._inputService = input;
            this._weaponService = weaponService;
        }

        public void Enable()
        {
            this._inputService.OnFire += this.OnFire;
            this._inputService.OnMove += this.OnMove;
            this._player.HitPointsComponent.OnDeath += FinishGameHandler.OnPlayerDeath;
        }

        public void Disable()
        {
            this._inputService.OnFire -= this.OnFire;
            this._inputService.OnMove -= this.OnMove;
            this._player.HitPointsComponent.OnDeath -= FinishGameHandler.OnPlayerDeath;
        }

        private void OnFire()
        {
            this._weaponService.Fire(
                this._player.TeamComponent,
                this._player.WeaponComponent,
                Vector2.up);
        }

        private void OnMove(Vector2 moveDirection)
        {
            if (moveDirection != Vector2.zero)
            {
                this._player.MoveComponent.MoveByRigidbodyVelocity(moveDirection * Time.fixedDeltaTime);
            }
        }
    }
}