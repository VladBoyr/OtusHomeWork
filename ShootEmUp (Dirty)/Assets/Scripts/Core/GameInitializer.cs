using Player;
using UnityEngine;
using Weapons;

namespace Core
{
    public sealed class GameInitializer : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private PlayerUnit playerUnit;
        [SerializeField] private PlayerInputService playerInputService;

        [Header("Weapons")]
        [SerializeField] private WeaponService weaponService;

        private PlayerController _playerController;

        private void Awake()
        {
            this._playerController = new PlayerController(
                this.playerUnit,
                this.playerInputService,
                this.weaponService);
        }

        private void OnEnable()
        {
            this._playerController.Enable();
        }

        private void OnDisable()
        {
            this._playerController.Disable();
        }
    }
}