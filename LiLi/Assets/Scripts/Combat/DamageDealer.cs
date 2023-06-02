using UnityEngine;

namespace Lili.Combat{
    public class DamageDealer : MonoBehaviour {

        #region In Engine Comfigurable Params
        [SerializeField] private damageDealerType type;
        [SerializeField] private float damage = 20f;
        [SerializeField] private float pushForce = 30f;
        #endregion
        private float damageDirection = -1f; // TODO: Make this changeable for damage direction
        private Vector2 damageVector;
        #region Cache Referances
        Health targetHealth;  
        #endregion

       enum damageDealerType{
            Projectile,
            Sword,
            Trap
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.tag == "Terrain") Destroy(gameObject);
            try
            {
                targetHealth =  other.gameObject.GetComponent<Health>();
            }
            catch (System.Exception)
            {
                return;
            }
            if (targetHealth == null) return;
            if (this.type != damageDealerType.Trap){
                damageVector = new Vector2(pushForce * damageDirection, 0.5f);
            } else {
                damageVector = new Vector2(0,10);
            }
            StartCoroutine(targetHealth.TakeHit(damage, damageVector, this));
        }

        public void DestroyProjectile(DamageDealer damageDealer) {
            if (damageDealer.type == damageDealerType.Projectile) {
                Destroy(damageDealer.GetComponent<SpriteRenderer>());
                Destroy(damageDealer.GetComponent<BoxCollider2D>());
            }
        }
        
    }
}