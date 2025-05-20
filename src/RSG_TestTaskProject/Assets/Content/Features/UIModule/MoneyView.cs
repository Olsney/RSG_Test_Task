using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Content.Features.UIModule
{
    public class MoneyView : MonoBehaviour
    {
        private const float ANIMATION_DURATION = 0.3f;
        
        [SerializeField] private TextMeshProUGUI _text;

        private Tween _moneyTween;
        private float _lastMoney;

        public void SetMoney(float money)
        {
            _moneyTween?.Kill();

            _moneyTween = DOVirtual
                .Float(_lastMoney, money, ANIMATION_DURATION, value => { _text.text = $"Gold: {Mathf.FloorToInt(value)}"; })
                .OnComplete(() => _lastMoney = money);
        }
    }
}