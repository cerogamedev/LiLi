using UnityEngine;
using Lili.Core;
using Lili.Combat;

namespace Lili.Control {

    public class PlayerController : MonoBehaviour
    {
        // Configurable Variables
        [SerializeField] float speed = 5f;
        // Cache Reff
        Animator animator;
        SpriteRenderer spriteRenderer;
        private void Awake() {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        private void Update() {
            Movement();
            
        }

        private void Movement(){
            float velocity = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            if (velocity < 0) {
                spriteRenderer.flipX = true;
            } else if (velocity > 0) { 
                spriteRenderer.flipX = false;
            }            
            
            transform.Translate(velocity,0,0);
            if (velocity != 0) {
                    animator.SetBool("isRunning", true);
            } else {
                animator.SetBool("isRunning", false);
            }
        }

    }
}

