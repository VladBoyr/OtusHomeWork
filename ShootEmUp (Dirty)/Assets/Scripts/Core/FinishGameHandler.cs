using UnityEngine;

namespace Core
{
    public static class FinishGameHandler
    {
        public static void OnPlayerDeath(GameObject playerObject)
        {
            FinishGame();
        }

        private static void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}