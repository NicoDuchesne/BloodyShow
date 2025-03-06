using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnableAnim : MonoBehaviour
{
    public Animator animator;

    public void LaunchAnim() {
        animator.enabled = true;
    }
}
