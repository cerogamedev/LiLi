using System;
using System.Collections;
using UnityEngine;

namespace Lili.Combat {
    public class Resources : MonoBehaviour {

        #region CONSTANT STATS
        const float MAX_STAMINA = 100f;
        const float MAX_MANA = 100f;
        const float MAX_REGENABLE_MANA = 50f;
        [SerializeField] const float MANA_RECOVERY_RATE =5f;
        [SerializeField] const float STAMINA_RECOVERY_RATE =5f;
        [SerializeField] const float RECOVERY_RATE_FREQUENCY = 1f; // In seconds
        #endregion

        #region CHECKS
        [HideInInspector] public float currentStamina = MAX_STAMINA;
        [HideInInspector] public float currentMana = MAX_REGENABLE_MANA;
        private bool isRecoveringMana = false;
        private bool isRecoveringStamina = false;
        #endregion
        private void FixedUpdate() {
            StartRegen();
        }

        private void StartRegen()
        {
            if (!isRecoveringStamina){
                StartCoroutine(StaminaRegen());
            }
            if (!isRecoveringMana) {
                StartCoroutine(ManaRegen());
            }
        }

        public bool ConsumeStamina(float requiredStamina) {
            if (currentStamina >= requiredStamina) {
                currentStamina -= requiredStamina;
                return true;
            } else {
                return false;
            }
        } 
            public bool ConsumeMana(float requiredMana) {
            if (currentMana >= requiredMana) {
                currentMana -= requiredMana;
                return true;
            } else {
                return false;
            }
        }
        public void GainMana(float gainedMana){
            currentMana = MathF.Min(currentMana+gainedMana , MAX_MANA);

        }

         public IEnumerator StaminaRegen(){
            isRecoveringStamina = true;
            while (currentStamina < MAX_STAMINA) {
                yield return new WaitForSeconds(RECOVERY_RATE_FREQUENCY);
                currentStamina = Mathf.Min(currentStamina+ STAMINA_RECOVERY_RATE , MAX_STAMINA);
            }
            isRecoveringStamina = false;
        }   
        public IEnumerator ManaRegen(){
            isRecoveringMana = true;
            while (currentMana < MAX_REGENABLE_MANA) {
                yield return new WaitForSeconds(RECOVERY_RATE_FREQUENCY);
                currentMana = Mathf.Min(currentMana+ MANA_RECOVERY_RATE , MAX_REGENABLE_MANA);
            }
            isRecoveringMana = false;
        }
        
    }

}