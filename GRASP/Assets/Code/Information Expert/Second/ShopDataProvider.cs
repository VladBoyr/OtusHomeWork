using System.Collections.Generic;

namespace GRASP.Second
{    
    public readonly struct Item
    {
        public readonly string Id;
        public readonly int Price;
        public readonly int Quantity;

        public Item(string id, int price, int quantity)
        {
            Id = id;
            Price = price;
            Quantity = quantity;
        }
    }
    
    public readonly struct Shop
    {
        public readonly string Id;
        public readonly Item[] Items;
    }
    
    public sealed class ShopDataProvider
    {
        public IReadOnlyList<Shop> Shops => _allShops;
        private readonly List<Shop> _allShops = new ();
        
        private readonly Dictionary<string, Item[]> _shops = new ();
        
        public bool TryGetListItemByShopId(string shopId, out Item[] items)
        {
            return _shops.TryGetValue(shopId, out items);
        }
    }
    
    public sealed class ShopController
    {
        private readonly ShopDataProvider _shopDataProvider;
        
        public ShopController(ShopDataProvider shopDataProvider)
        {
            _shopDataProvider = shopDataProvider;
        }
        
        public int GetTotalPrice(string shopId)
        {
            if (_shopDataProvider.TryGetListItemByShopId(shopId, out var items) == false)
            {
                return 0;
            }
            
            int totalPrice = 0;
            
            foreach (var item in items)
            {
                totalPrice += item.Price * item.Quantity;
            }
            
            return totalPrice;
        }
    }
}
