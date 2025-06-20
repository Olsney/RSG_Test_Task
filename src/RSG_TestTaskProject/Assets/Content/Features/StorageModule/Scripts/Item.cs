﻿using UnityEngine;

namespace Content.Features.StorageModule.Scripts {
    public class Item {
        public string Name { get; private set; }
        public Sprite Icon { get; private set; }
        public int Price { get; private set; }
        public float Weight { get; private set; }
        public ItemType ItemType { get; private set; }
        public float HealValue { get; private set; }

        public Item(string name, Sprite icon, int price, float weight) {
            Name = name;
            Icon = icon;
            Price = price;
            Weight = weight;
        }
    
        public Item(ItemConfiguration itemConfiguration) {
            Weight = itemConfiguration.Weight;
            Name = itemConfiguration.Name;
            Icon = itemConfiguration.Icon;
            Price = itemConfiguration.Price;
            ItemType = itemConfiguration.ItemType;
            HealValue = itemConfiguration.HealValue;
        }
    }
}