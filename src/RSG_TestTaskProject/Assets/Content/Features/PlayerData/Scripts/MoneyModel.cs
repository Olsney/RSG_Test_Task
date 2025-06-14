﻿using System;

namespace Content.Features.PlayerData.Scripts
{
    public class MoneyModel {
        public int CurrentMoney { get; private set; }

        public event Action<int> MoneyChanged;
        
        public void AddMoney(int amount) {
            if (amount <= 0)
                return;
            
            CurrentMoney += amount;
            
            MoneyChanged?.Invoke(CurrentMoney);
        }

        public void Pay(int price) {
            if (price >= CurrentMoney)
                return;

            if (price < 0)
                price = 0;
            
            CurrentMoney -= price;
            
            MoneyChanged?.Invoke(CurrentMoney);
        }
    }
}