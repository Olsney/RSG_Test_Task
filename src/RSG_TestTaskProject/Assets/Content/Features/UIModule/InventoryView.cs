using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Content.Features.UIModule
{
    public class InventoryView : MonoBehaviour {
        private const float ANIMATION_DURATION = 0.5f;

        [SerializeField] private TextMeshProUGUI _itemCountText;
        [SerializeField] private TextMeshProUGUI _currentWeightText;
        [SerializeField] private TextMeshProUGUI _maxWeightText;

        private Tween _itemTween;
        private Tween _weightTween;

        private int _lastItemCount;
        private float _lastWeight;

        public void SetItemInfo(int itemsCount, float currentWeight, float maxWeight) {
            _itemTween?.Kill();
            _itemTween = DOVirtual
                .Int(_lastItemCount, itemsCount, ANIMATION_DURATION, value =>
                {
                    _itemCountText.text = $"Items: {value}";
                })
                .OnComplete(() => _lastItemCount = itemsCount);

            _weightTween?.Kill();
            _weightTween = DOVirtual
                .Float(_lastWeight, currentWeight, ANIMATION_DURATION, value =>
                {
                    _currentWeightText.text = $"Weight: {Mathf.CeilToInt(value)}";
                })
                .OnComplete(() => _lastWeight = currentWeight);

            _maxWeightText.text = $"Max: {Mathf.CeilToInt(maxWeight)}";
        }
    }
}