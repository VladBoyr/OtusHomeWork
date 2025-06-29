namespace GRASP
{
    public sealed class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public int GetTotalPrice()
        {
            return Price * Quantity;
        }
    }
}
