using TMPro;
using UnityEngine;

namespace Content.Features.UIModule
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        
        public void SetHealth(float health) => 
            _healthText.text = health.ToString();
    }
}