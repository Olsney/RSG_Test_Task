﻿using System;

namespace Content.Features.DamageablesModule.Scripts
{
    public class HealthProvider {
        private bool _isInitialized;
        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }

        public event Action<float> HealthChanged;

        public void Initialize(float startHealth) {
            if (_isInitialized)
                return;
            
            MaxHealth = startHealth;
            CurrentHealth = startHealth;
            
            _isInitialized = true;
            
            SetHealth(CurrentHealth);
        }
        
        public void SetHealth(float health) {
            if (health <= 0)
                return;
            
            CurrentHealth = health;
            
            HealthChanged?.Invoke(CurrentHealth);
        }
    }
}