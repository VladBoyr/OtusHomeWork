using Enemies;
using Player;
using UnityEngine;
using UnityEngine.Serialization;
using Weapons;

namespace Core
{
    public sealed class GameInitializer : MonoBehaviour
    {
        [FormerlySerializedAs("playerFacade")]
        [Header("Player")]
        [SerializeField] private PlayerUnit playerUnit;
        [SerializeField] private PlayerInputService playerInputService;

        [Header("Enemies")]
        [SerializeField] private EnemyFactory enemyFactory;
        [SerializeField] private EnemySpawningSystem enemySpawningSystem;

        [Header("Services")]
        [SerializeField] private BulletService bulletService;

        [Header("Game State")]
        [SerializeField] private GameStateController gameStateController;

        private PlayerController _playerController;

        private void Awake()
        {
            this.bulletService.Initialize();
            var weaponService = new WeaponService(this.bulletService);

            this.enemyFactory.Initialize(this.playerUnit);
            this.enemySpawningSystem.Initialize(weaponService);

            this._playerController = new PlayerController(
                this.playerUnit,
                this.playerInputService,
                weaponService);

            this.gameStateController.Initialize(playerUnit);
        }

        private void OnEnable()
        {
            this._playerController.Enable();
            this.gameStateController.Enable();
        }

        private void OnDisable()
        {
            this._playerController.Disable();
            this.gameStateController.Disable();
        }
    }
}