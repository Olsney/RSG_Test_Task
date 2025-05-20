using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Content.Features.UIModule
{
    public class HealView : MonoBehaviour
    {
        [SerializeField] private Button _healButton;
        [SerializeField] private TextMeshProUGUI _countText;

        public event Action HealClicked;
        
        private void Awake()
        {
            _healButton.onClick.AddListener(() => HealClicked?.Invoke());
        }

        public void SetHealPotionsInfo(int count)
        {
            _countText.text = $"{count}";
            _healButton.interactable = IsHealToUseExist(count);
        }

        private static bool IsHealToUseExist(int count) => 
            count > 0;
    }
}