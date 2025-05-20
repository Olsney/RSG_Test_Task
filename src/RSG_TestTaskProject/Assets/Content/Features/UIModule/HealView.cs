using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Content.Features.UIModule
{
    public class HealView : MonoBehaviour {
        private const float ANIMATION_DURATION = 0.5f;
        
        [SerializeField] private Button _healButton;
        [SerializeField] private TextMeshProUGUI _countText;

        public event Action HealClicked;
        
        private Tween _countTween;
        
        private void Awake() {
            _healButton.onClick.AddListener(() => HealClicked?.Invoke());
        }

        public void SetHealPotionsInfo(int count) {
            _countTween?.Kill();
            _countTween = DOVirtual.Int(
                int.Parse(_countText.text),
                count,
                ANIMATION_DURATION,
                value => _countText.text = value.ToString()
            );

            _healButton.interactable = IsHealToUseExist(count);
        }

        private static bool IsHealToUseExist(int count) => 
            count > 0;
    }
}