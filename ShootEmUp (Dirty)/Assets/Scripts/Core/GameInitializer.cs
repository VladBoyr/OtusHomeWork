using Enemies;
using Player;
using UnityEngine;
using WeaponSystem;

namespace Core
{
    public sealed class GameInitializer : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private PlayerFacade playerFacade;
        [SerializeField] private PlayerInputService playerInputService;
        [SerializeField] private BulletConfig playerBulletConfig;

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
            this.enemyFactory.Initialize(this.playerFacade);
            this.enemySpawningSystem.Initialize(weaponService);

            this._playerController = new PlayerController(
                this.playerInputService,
                this.playerFacade, 
                weaponService,
                this.playerBulletConfig);

            this.gameStateController.Initialize(playerFacade);
        }

        private void OnEnable()
        {
            this._playerController.Enable();
            this.gameStateController.Enable();
        }

        private void Start()
        {
            this.enemySpawningSystem.StartSpawning();
        }

        private void FixedUpdate()
        {
            this._playerController.OnFixedUpdate();
        }

        private void OnDisable()
        {
            this._playerController.Disable();
            this.gameStateController.Disable();
        }
    }
}