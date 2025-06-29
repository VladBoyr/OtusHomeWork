using System.Collections.Generic;

namespace GRASP.Controller
{
    public sealed class InventoryItem
    {
        public object StatType { get; }
        public object StatValue { get; }
    }

    public interface IInventoryListener
    {
        void OnItemAdded(InventoryItem item);
    }
    
    public sealed class Inventory
    {
        private List<InventoryItem> _items;
        
        private List<IInventoryListener> _listeners;

        public void AddListener(IInventoryListener listener)
        {
            _listeners.Add(listener);
        }
    
        public void RemoveListener(IInventoryListener listener)
        {
            _listeners.Remove(listener);
        }
    
        public void AddItem(InventoryItem item)
        {
            _items.Add(item);
            for (var index = 0; index < _listeners.Count; index++)
            {
                IInventoryListener listener = _listeners[index];
                listener.OnItemAdded(item);
            }
        }
    }


    public class InventoryStatsListener : IInventoryListener 
    {
        private Player _player;
    
        public void OnItemAdded(InventoryItem item)
        {
            _player.AddStat(item.StatType, item.StatValue);
        }
    }

    internal class Player
    {
        public void AddStat(object statType, object statValue)
        {
            
        }
    }
}
