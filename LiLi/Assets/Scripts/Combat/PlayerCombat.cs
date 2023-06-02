using UnityEngine;
using System.Collections;

namespace Lili.Combat {
        public class PlayerCombat : MonoBehaviour {

            #region Checks
            private bool canAttack = false;
            private bool isDrawingTheBow = false;
            #endregion
            #region Components
            Animator animator;
            SpriteRenderer spriteRenderer;
           // [SerializeField] GameObject arrowPrefab;
            [SerializeField] Transform projectileFirePointRight;
            [SerializeField] Transform projectileFirePointLeft;
            [SerializeField] float projectileForce = 20;

            #endregion
            private void Awake() {
                animator = GetComponent<Animator>();
                spriteRenderer = GetComponent<SpriteRenderer>();
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

            public void FireArrows(GameObject arrow){ // Triggered by bowAttack1 anim
                if (spriteRenderer.flipX) { // if player rotates left
                    GameObject newArrow = Instantiate(arrow, projectileFirePointLeft.position, projectileFirePointLeft.rotation); // istantiate bow
                    newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * projectileForce * -1f; // set velocity 
                    newArrow.GetComponent<SpriteRenderer>().flipX = true; // flip arrow for make sense miyav
                } else {
                    GameObject newArrow = Instantiate(arrow, projectileFirePointRight.position, projectileFirePointRight.rotation);
                    newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * projectileForce;
                    print("right");
                }
            
            }


        }


}
