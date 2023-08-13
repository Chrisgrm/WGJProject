using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{

    public Animator animator;

    public void FadeStart()
    {
        animator.SetTrigger("FadeStart");
    }
}
