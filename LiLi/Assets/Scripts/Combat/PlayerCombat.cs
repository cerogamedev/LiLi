using UnityEngine;
using Lili.Core;
using System.Collections;

namespace Lili.Combat {
        public class PlayerCombat : MonoBehaviour {

            private bool canAttack = false;
            private bool isDrawingTheBow = false;
            Animator animator;
            private void Awake() {
                animator = GetComponent<Animator>();
            }

            private void Update()
        {
            BowAttack();
        }

        private void BowAttack()
        {
            if (Input.GetMouseButton(1) && !isDrawingTheBow)
            {
                DrawTheBow();
            }
            if (canAttack && Input.GetMouseButtonUp(1))
            {
                FreeTheBow();
            }
            else if (!canAttack && Input.GetMouseButtonUp(1))
            {
                StartCoroutine(CancelAttack());
            }
        }

        public void DrawTheBow(){

                animator.SetTrigger("drawBow");
                isDrawingTheBow = true;

            }
            public void FreeTheBow(){
                animator.SetTrigger("fireArrow");
                canAttack = false;
                isDrawingTheBow = false;
            }

            public void fullyDrew(){ //Triggered By Bow Animation
                canAttack = true;
            }
            public IEnumerator CancelAttack(){
               animator.SetTrigger("cancelAttack");
               yield return new WaitForSecondsRealtime(1f);
               isDrawingTheBow = false;
               animator.ResetTrigger("cancelAttack");
            }


        }


}
