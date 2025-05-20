using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Content.Features.UIModule
{
    public class HealthView : MonoBehaviour
    {
        private const float AnimationDuration = 0.5f;
        
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private Image _currentHealth;
        
        private Tween _fillTween;
        private Tween _textTween;
        
        private float _lastHealthValue = 0;
        
        public void SetHealth(float health, float maxHealth)
        {
            _healthText.text = Mathf.CeilToInt(health).ToString();

            float targetFill = Mathf.Clamp01(health / maxHealth);

            _fillTween?.Kill();

            _fillTween = _currentHealth.DOFillAmount(targetFill, AnimationDuration)
                .SetEase(Ease.OutQuad);
            
            _textTween?.Kill();
            _textTween = DOVirtual.Float(
                _lastHealthValue,
                health,
                AnimationDuration,
                value => _healthText.text = Mathf.CeilToInt(value).ToString()
            ).OnComplete(() => _lastHealthValue = health);
        }
    }
}