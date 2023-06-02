using System.Collections;
using UnityEngine;

namespace Lili.Combat {
    
    public class Health : MonoBehaviour {
        #region CONSTANTS
        const float MAX_HEALTH = 100f;
        #endregion
        #region CHECKS
        [HideInInspector] public float currentHealth = MAX_HEALTH;
        public bool isDead = false;
        public bool isTakingDamage = false;
        private bool damageImmune = false;
        #endregion
        #region PARAMS
        [SerializeField] private float immuneDuration = 5f; // In Seconds
        #endregion
        #region COMPONENTS
        Rigidbody2D rb;
        #endregion
        private void Awake() {
            rb = GetComponent<Rigidbody2D>(); // Get component when initialize gameobject
        }

        public IEnumerator TakeHit(float damage, Vector2 damageVector, DamageDealer damageDealer) {
            if (!damageImmune) { // Checks if character has damage immunity
                currentHealth -= damage;  // TODO: Add taking hit anim
                if (currentHealth <= 0) {
                    isDead = true; // TODO: Add Death Anim
                }
                damageImmune = true; // Gain damage immunity
                rb.gravityScale = 0;
                rb.velocity = new Vector2(transform.localScale.x * damageVector[0], transform.localScale.y * damageVector[1]);
                isTakingDamage = true; // Take control from player for a little time
                damageDealer.DestroyProjectile(damageDealer); // Destroy damageDealer if its a projectile
                yield return new WaitForSeconds(0.1f);
                isTakingDamage = false;
                rb.gravityScale = 1;
                rb.velocity = new Vector2(0, transform.localScale.y);
                yield return new WaitForSeconds(immuneDuration); // Wait for lose damage immunity
                damageImmune = false; // lose damage immunity
            } else {
                yield return null;
            }
        }

        public void Heal(float healthPoint) {
            currentHealth = Mathf.Max(currentHealth + healthPoint , MAX_HEALTH);
        }
        
    }
}