using System;
using UnityEngine;

namespace GRASP
{
    class Main : MonoBehaviour
    {
        [SerializeField] private Player _player;
        
        private void Start()
        {
            PlayerRepository playerRepository = new PlayerRepository(new PlayerPrefsSaver(), _player);
        }
    }
    
    
    public class PlayerRepository
    {
        private const string NameKey = "Name";
        
        private readonly PlayerPrefsSaver _playerPrefsSaver;
        private readonly Player _player;

        public PlayerRepository(PlayerPrefsSaver playerPrefsSaver, Player player)
        {
            _playerPrefsSaver = playerPrefsSaver;
            _player = player;
        }
        
        public void Save()
        {
            _playerPrefsSaver.Save(NameKey, _player.Name);
        }
        
        public void Load()
        {
            _player.Name = _playerPrefsSaver.Load(NameKey);
        }
    }
}
