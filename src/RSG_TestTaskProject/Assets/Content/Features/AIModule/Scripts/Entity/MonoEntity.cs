﻿using Content.Features.AIModule.Scripts.Entity.EntityBehaviours;
using Content.Features.DamageablesModule.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.AIModule.Scripts.Entity
{
    public class MonoEntity : MonoBehaviour, IEntity {
        [SerializeField] private EntityContext _entityContext;
        [SerializeField] private EntityType _entityType;
        [SerializeField] private bool _isAggressive;

        private HealthProvider _healthProvider;

        private IEntityBehaviour _currentBehaviour;

        private IEntityDataService _entityDataService;

        private IStorage _storage;
        private IEntityBehaviourFactory _entityBehaviourFactory;

        [Inject]
        public void InjectDependencies(
            IEntityDataService entityDataService,
            IStorage storage,
            IEntityBehaviourFactory entityBehaviourFactory,
            HealthProvider healthProvider
        ) {
            _entityBehaviourFactory = entityBehaviourFactory;
            _storage = storage;
            _entityDataService = entityDataService;
            _healthProvider = healthProvider;
        }

        private void Awake() {
            _entityContext.Entity = this;
            _entityContext.EntityDamageable = GetComponent<IDamageable>();
            _entityContext.EntityData = _entityDataService.GetEntityData(_entityType);


            if (_entityType == EntityType.Player)
            {
                _healthProvider.Initialize(_entityContext.EntityData.StartHealth);

                _entityContext.EntityDamageable.SetHealth(_healthProvider.CurrentHealth);
            }
            else
            {
                _entityContext.EntityDamageable.SetHealth(_entityContext.EntityData.StartHealth);
            }

            _entityContext.Storage = _storage;

            SetDefaultBehaviour();
        }

        private void Update() =>
            _currentBehaviour.Process();

        private void OnDestroy() {
            if (_currentBehaviour == null)
                return;

            _currentBehaviour.Stop();
            _currentBehaviour.OnBehaviorEnd -= OnBehaviourEnded;
        }

        public void SetBehaviour(IEntityBehaviour entityBehaviour) {
            if (_currentBehaviour != null)
            {
                _currentBehaviour.Stop();
                _currentBehaviour.OnBehaviorEnd -= OnBehaviourEnded;
            }

            _currentBehaviour = entityBehaviour;
            _currentBehaviour.OnBehaviorEnd += OnBehaviourEnded;
            _currentBehaviour.InitContext(_entityContext);
            _currentBehaviour.Start();
        }

        public EntityContext GetContext() =>
            _entityContext;

        private void OnBehaviourEnded() =>
            SetDefaultBehaviour();

        private void SetDefaultBehaviour() {
            if (_isAggressive)
                SetBehaviour(_entityBehaviourFactory.GetEntityBehaviour<IdleSearchForTargetsEntityBehaviour>());
            else
                SetBehaviour(_entityBehaviourFactory.GetEntityBehaviour<IdleEntityBehaviour>());
        }
    }
}