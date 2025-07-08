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
            this._inputService.OnFire += this.Fire;
            this._inputService.OnMove += this.Move;
            this._player.HitPointsComponent.OnDeath += FinishGameHandler.OnPlayerDeath;
        }

        public void Disable()
        {
            this._inputService.OnFire -= this.Fire;
            this._inputService.OnMove -= this.Move;
            this._player.HitPointsComponent.OnDeath -= FinishGameHandler.OnPlayerDeath;
        }

        private void Fire()
        {
            this._weaponService.Fire(this._player.TeamComponent, this._player.WeaponComponent, Vector2.up);
        }

        private void Move(Vector2 moveDirection)
        {
            this._player.MoveComponent.SetVelocity(moveDirection);
        }
    }
}