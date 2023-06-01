using UnityEngine;

namespace Lili.Combat {
    
    public class Health : MonoBehaviour {
        const float MAX_HEALTH = 100f;
        [HideInInspector] public float currentHealth;
        public bool isDead = false;

        public void TakeHit(float damage) {
            currentHealth -= damage;
            if (currentHealth <= 0) {
                // TODO: ADD DEATH ANIM
                isDead = true;
            }
        }

        public void Heal(float healthPoint) {
            currentHealth = Mathf.Max(currentHealth + healthPoint , MAX_HEALTH);
        }


        
    }
}