using System;
using Content.Features.InteractionModule;
using UnityEngine;
using Zenject;

namespace Content.Features.DamageablesModule.Scripts {
    public class MonoDamageable : MonoBehaviour, IDamageable
    {
        [SerializeField] public float _health;
        [SerializeField] private DamageableType _damageableType;
        [SerializeField] private AttackInteractable _attackInteractable;
        
        private HealthProvider _healthProvider;

        [Inject]
        public void Construct(HealthProvider healthProvider)
        {
            _healthProvider = healthProvider;
        }

        public Vector3 Position =>
            transform.position;

        public DamageableType DamageableType =>
            _damageableType;

        public bool IsActive =>
            _health > 0;

        public AttackInteractable Interactable =>
            _attackInteractable;

        public event Action OnDamaged;
        public event Action OnKilled;

        public void Damage(float damage) {
            _health -= damage;

            if (_healthProvider != null) 
                _healthProvider.SetHealth(_health);
            
            OnDamaged?.Invoke();

            if (_health > 0)
                return;

            OnKilled?.Invoke();
            Destroy(gameObject);
        }

        public void SetHealth(float health) =>
            _health = health;

        public float GetHealth() => 
            _health;
    }
}