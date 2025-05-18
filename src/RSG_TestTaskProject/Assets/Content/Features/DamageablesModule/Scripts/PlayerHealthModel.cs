using Content.Features.AIModule.Scripts.Entity;

namespace Content.Features.DamageablesModule.Scripts
{
    public class PlayerHealthModel
    {
        public PlayerEntityModel EntityModel;

        public PlayerHealthModel(PlayerEntityModel entityModel)
        {
            EntityModel = entityModel;
        }

        private void GetHealth()
        {
            float currentHealth = EntityModel.PlayerEntity.GetContext().EntityDamageable.GetHealth();
        }
    }
}