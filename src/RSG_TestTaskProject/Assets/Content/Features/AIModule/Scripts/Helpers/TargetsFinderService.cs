using Content.Features.DamageablesModule.Scripts;
using UnityEngine;

namespace Content.Features.AIModule.Scripts.Helpers {
    public class TargetsFinder : MonoBehaviour {
        [SerializeField] private DamageableType _damageableTypeToSearch;
        [SerializeField] private float _radius;
        
        public bool TryFindDamageable(out IDamageable damageable) {
            damageable = null;
            Collider[] foundColliders = Physics.OverlapSphere(transform.position, _radius);
        
            foreach (Collider foundCollider in foundColliders) {
                if (foundCollider.TryGetComponent(out IDamageable foundDamageable) is false)
                    continue;

                if (foundDamageable.IsActive is false)
                    continue;
                
                if (foundDamageable.DamageableType != _damageableTypeToSearch)
                    continue;

                damageable = foundDamageable;
            }

            return damageable != null;
        }
    }
}
