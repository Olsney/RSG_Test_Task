using Content.Features.PlayerData.Scripts;

namespace Content.Features.UIModule
{
    public class MoneyPresenter :  Presenter<MoneyView> {
        private readonly MoneyModel _moneyModel;

        public MoneyPresenter(MoneyView moneyView, MoneyModel moneyModel) : base(moneyView) {
            _moneyModel = moneyModel;
        }

        public override void Initialize() {
            UpdateView(_moneyModel.CurrentMoney);
            
            _moneyModel.MoneyChanged += OnMoneyChanged;
        }

        public override void Dispose() {
            _moneyModel.MoneyChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int money) =>
            UpdateView(money);

        private void UpdateView(float money) => 
            View.SetMoney(money);
    }
}