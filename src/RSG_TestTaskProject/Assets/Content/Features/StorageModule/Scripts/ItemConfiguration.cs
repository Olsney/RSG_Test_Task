﻿using System;
using UnityEngine;

namespace Content.Features.StorageModule.Scripts {
    [Serializable]
    public class ItemConfiguration {
        public ItemType ItemType;
        public string Name;
        public Sprite Icon;
        public int Price;
        public float Weight;
        public float HealValue;
    }
}