using TMPro;
using UnityEngine;

namespace GRASP
{
    public sealed class UIShop : MonoBehaviour
    {
        [SerializeField] private TMP_Text _totalPrice;
        
        private Shop _shop;

        private void Awake()
        {
            _totalPrice.text = $"Total price: {_shop.GetTotalPrice().ToString()}";
        }
    }
}
