namespace GRASP
{
    public sealed class PlayerPrefsSaver
    {
        public void Save(string key, string value)
        {
            UnityEngine.PlayerPrefs.SetString(key, value);
        }
        
        public string Load(string key)
        {
            return UnityEngine.PlayerPrefs.GetString(key);
        }
    }


    class InventoryController
    {
        private void SpawnItem()
        {
          // UnityEngine.PlayerPrefs.SetString(key, value);
        }
    }
}
