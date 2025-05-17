using System.Collections.Generic;

namespace Content.Features.StorageModule.Scripts
{
    public class StorageModel
    {
        private readonly List<Item> _items = new List<Item>();
        private readonly float _maxWeight;

        private float _currentWeight;

        public StorageModel(float maxWeight)
        {
            _maxWeight = maxWeight;
            _currentWeight = 0f;
        }

        public float CurrentWeight { get; private set; }
        
        public float MaxWeight => _maxWeight;
        public List<Item> Items => new List<Item>(_items);
    }
}