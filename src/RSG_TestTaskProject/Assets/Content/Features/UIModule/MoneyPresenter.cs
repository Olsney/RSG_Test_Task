using Content.Features.PlayerData.Scripts;

namespace Content.Features.UIModule
{
    public class MoneyPresenter
    {
        private readonly MoneyView _moneyView;
        private readonly MoneyModel _moneyModel;

        public MoneyPresenter(MoneyView moneyView, MoneyModel moneyModel)
        {
            _moneyView = moneyView;
            _moneyModel = moneyModel;
            
            _moneyModel.MoneyChanged += OnMoneyChanged;
        }

        private void OnMoneyChanged(int money) =>
            UpdateView(money);

        private void UpdateView(float money) => 
            _moneyView.SetMoney(money);
    }
}