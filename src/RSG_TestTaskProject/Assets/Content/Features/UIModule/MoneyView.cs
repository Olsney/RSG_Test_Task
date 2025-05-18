using TMPro;
using UnityEngine;

namespace Content.Features.UIModule
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public void SetMoney(float money) => 
            _text.text = $"Money: {money}";
    }
}