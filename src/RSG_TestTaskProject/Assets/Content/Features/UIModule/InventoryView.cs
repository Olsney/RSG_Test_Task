using TMPro;
using UnityEngine;

namespace Content.Features.UIModule
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemCountText;
        [SerializeField] private TextMeshProUGUI _currentWeightText;
        [SerializeField] private TextMeshProUGUI _maxWeightText;
        
        public void SetItemInfo(int itemsCount, float currentWeight, float maxWeight)
        {
            _itemCountText.text = $"Items count: {itemsCount};" +
                                  $"\nCurrent weight: {currentWeight}" +
                                  $"\nMax weight: {maxWeight}";
        }
    }
}