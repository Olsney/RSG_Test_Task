using UnityEngine;

namespace Content.Features.UIModule
{
    public class GameUIView : MonoBehaviour
    {
        [field: SerializeField] public HealthView HealthView { get; private set; } 
        [field: SerializeField] public InventoryView InventoryView { get; private set; }
        [field: SerializeField] public MoneyView MoneyView { get; private set; }
        [field: SerializeField] public HealView HealView { get; private set; }
    }
}