using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioAnimations
{
    public class MarioAnimationController : MonoBehaviour
    {
        private Animator animator;
        private MarioMovement mario;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            mario = GetComponent<MarioMovement>();
        }
    }
}
