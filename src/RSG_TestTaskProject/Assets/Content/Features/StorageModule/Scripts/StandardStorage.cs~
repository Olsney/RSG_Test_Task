using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Content.Features.StorageModule.Scripts {
    public class StandardStorage : IStorage {
        private List<Item> _items = new List<Item>();

        private float _maxWeight;
        private float _currentWeight;

        public StandardStorage(float maxWeight)
        {
            _maxWeight = maxWeight;
            _currentWeight = 0f;
        }

        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;

        public List<Item> GetAllItems() =>
            _items.ToList();

        public bool TryAddItem(Item item) {
            if(_items.Contains(item))
                return false;

            if (IsWeightLimitExceeded(item))
                return false;
        
            _items.Add(item);
            AddNewItemWeight(item);
            OnItemAdded?.Invoke(item);

            return true;
        }

        public void AddItems(List<Item> items) {
            foreach (Item item in items)
                TryAddItem(item);
        }

        public void RemoveItem(Item item) {
            if(_items.Contains(item) is false)
                return;
            
            _items.Remove(item);
            RemoveItemWeight(item);
            OnItemRemoved?.Invoke(item);
        }

        public void RemoveItems(List<Item> items) {
            foreach (Item item in items)
                RemoveItem(item);
        }

        public void RemoveAllItems() {
            foreach (Item item in _items)
                RemoveItem(item);
        }

        private bool IsWeightLimitExceeded(Item item) => 
            _currentWeight + item.Weight > _maxWeight;

        private void AddNewItemWeight(Item item) => 
            _currentWeight += item.Weight;

        private void RemoveItemWeight(Item item)
        {
            if (_currentWeight - item.Weight < 0)
            {
                _currentWeight = 0;

                return;
            }
            
            _currentWeight -= item.Weight;
        }
    }
}