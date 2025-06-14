﻿using System;
using System.Collections.Generic;
using System.Linq;
using Content.Features.PlayerData.Scripts;
using Content.Features.ShopModule.Scripts;
using Content.Features.StorageModule.Scripts;
using UnityEngine;
using Zenject;

namespace Content.Features.AIModule.Scripts.Entity.EntityBehaviours {
    public class SellItemsEntityBehaviour : IEntityBehaviour {
        private EntityContext _entityContext;
        private Trader _trader;
        private MoneyModel _moneyModel;

        public event Action OnBehaviorEnd;

        [Inject]
        public void InjectDependencies(MoneyModel moneyModel) {
            _moneyModel = moneyModel;
        }
        public void InitContext(EntityContext entityContext) =>
            _entityContext = entityContext;
        
        public void SetTrader(Trader trader) =>
            _trader = trader;

        public void Start() =>
            _entityContext.NavMeshAgent.speed = _entityContext.EntityData.Speed;

        public void Process() {
            if(IsNearTheTarget())
                SellItems();
            else
                MoveToTarget();
        }

        public void Stop() { }

        private void MoveToTarget() =>
            _entityContext.NavMeshAgent.SetDestination(_trader.transform.position);

        private void StopMoving() =>
            _entityContext.NavMeshAgent.ResetPath();

        private bool IsNearTheTarget() =>
            Vector3.Distance(_entityContext.EntityDamageable.Position, _trader.transform.position) <= _entityContext.EntityData.InteractDistance;

        private void SellItems() {
            List<Item> itemsToSell = _entityContext.Storage
                .GetAllItems()
                .Where(item => item.ItemType == ItemType.Book)
                .ToList();
            
            int earnedMoney = _trader.SellItemsFromStorage(itemsToSell, _entityContext.Storage);
            
            _moneyModel.AddMoney(earnedMoney);
            
            StopMoving();
            OnBehaviorEnd?.Invoke();
        }
    }
}