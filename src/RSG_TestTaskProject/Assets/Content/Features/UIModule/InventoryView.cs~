using TMPro;
using UnityEngine;
using Zenject;

namespace Content.Features.UIModule
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private TextMeshProUGUI _itemCountText;
        
        public void SetItemInfo(int itemsCount, float currentWeight, float maxWeight)
        {
            _itemCountText.text = $"Items count: {itemsCount};" +
                                  $"\nCurrent weight: {currentWeight}" +
                                  $"\nMax weight: {maxWeight}";
        }
    }
}