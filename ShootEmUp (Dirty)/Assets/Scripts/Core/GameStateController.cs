using Player;
using UnityEngine;

namespace Core
{
    public sealed class GameStateController : MonoBehaviour
    {
        private PlayerFacade _playerFacade;

        public void Initialize(PlayerFacade playerFacade)
        {
            this._playerFacade = playerFacade;
        }

        public void Enable()
        {
            this._playerFacade.Health.OnHpEmpty += this.OnPlayerDeath;
        }

        public void Disable()
        {
            this._playerFacade.Health.OnHpEmpty -= this.OnPlayerDeath;
        }

        private void OnPlayerDeath(GameObject playerObject)
        {
            this.FinishGame();
        }

        private void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}