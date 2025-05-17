using System.Collections.Generic;
using System.Linq;

namespace Content.Features.StorageModule.Scripts
{
    public class StorageModel
    {
        private readonly List<Item> _items = new List<Item>();
        private readonly float _maxWeight;

        private float _currentWeight;

        public StorageModel()
        {
            _maxWeight = 30f;
            _currentWeight = 0f;
        }

        public float CurrentWeight => _currentWeight;
        public float MaxWeight => _maxWeight;

        public void Add(Item item)
        {
            _items.Add(item);
            
            _currentWeight += item.Weight;
        }

        public bool Remove(Item item)
        {
            if (_items.Remove(item) == false)
                return false;
            
            RemoveItemWeight(item);
            
            return true;
        }

        public List<Item> GetAllItems() =>
            _items.ToList();

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