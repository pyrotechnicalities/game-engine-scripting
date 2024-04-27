using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioAnimations
{
    public class MarioAnimationController : MonoBehaviour
    {
        private Animator animator;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }
        public void DoWalk()
        {
            animator.SetTrigger("Walk");
        }
        public void DoIdleWalk()
        {
            animator.ResetTrigger("Walk");
        }
        public void DoJump()
        {
            animator.SetBool("Jump", true);
        }
        public void DoIdleJump()
        {
            animator.SetBool("Jump", false);
        }
    }
}
