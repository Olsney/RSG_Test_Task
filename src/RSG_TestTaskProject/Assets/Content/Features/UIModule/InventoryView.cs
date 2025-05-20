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
            _itemCountText.text = $"Items: {itemsCount}";
            _currentWeightText.text = $"Weight: {currentWeight}";
            _maxWeightText.text = $"Max: {maxWeight}";
        }
    }
}