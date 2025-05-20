using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Content.Features.UIModule
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private Image _currentHealth;
        
        public void SetHealth(float health, float maxHealth)
        {
            _healthText.text = health.ToString();
            _currentHealth.fillAmount = health / maxHealth;
        }
    }
}