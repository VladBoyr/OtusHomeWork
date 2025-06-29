using System.Collections.Generic;

namespace GRASP
{
    public sealed class Shop
    {
        public IReadOnlyList<Item> Items => _items;
        
        private readonly List<Item> _items = new List<Item>();

        public int GetTotalPrice()
        {
            int totalPrice = 0;
            
            for (var index = 0; index < Items.Count; index++)
            {
                Item item = Items[index];
                totalPrice += item.GetTotalPrice();
            }

            return totalPrice;
        }
    }
}
