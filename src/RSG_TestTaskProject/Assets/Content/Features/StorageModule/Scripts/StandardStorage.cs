using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Content.Features.StorageModule.Scripts
{
    public class StandardStorage : IStorage
    {
        private List<Item> _items = new List<Item>();
        private readonly StorageModel _model;

        public StandardStorage(StorageModel model)
        {
            _model = model;
        }

        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;

        public List<Item> GetAllItems()
        {
            Debug.Log($"[STORAGE] Текущие предметы: {_model.GetAllItems().Count}");

            
            return _model.GetAllItems();
        }

        public bool TryAddItem(Item item)
        {
            if (IsAlreadyContained(item))
                return false;

            if (IsOverweight(item))
                return false;

            _model.Add(item);
            OnItemAdded?.Invoke(item);
            return true;
        }

        public void AddItems(List<Item> items)
        {
            foreach (var item in items)
                TryAddItem(item);
        }

        public void RemoveItem(Item item)
        {
            if (_model.Remove(item))
                OnItemRemoved?.Invoke(item);
        }

        public void RemoveItems(List<Item> items)
        {
            foreach (var item in items)
                RemoveItem(item);
        }

        public void RemoveAllItems()
        {
            foreach (var item in _model.GetAllItems())
                RemoveItem(item);
        }

        private bool IsAlreadyContained(Item item) =>
            _model.GetAllItems().Contains(item);

        private bool IsOverweight(Item item) =>
            _model.CurrentWeight + item.Weight > _model.MaxWeight;
    }
}