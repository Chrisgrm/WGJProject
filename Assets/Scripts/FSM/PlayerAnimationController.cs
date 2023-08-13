using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{   
    [SerializeField]
    private Animator animator;
    private int talkState;
    private int defeatState;

    private void Start()
    {
        talkState = 0; // Estado inicial de hablar
        defeatState = 0; // Estado inicial de derrota
    }

    public void SetIdle()
    {
        animator.SetTrigger("idle");
    }

    public void SetWalk()
    {
        animator.SetTrigger("walk");
    }

    public void SetTalk()
    {
        talkState = Random.Range(0, 1); // Elegir una de las dos animaciones de hablar al azar
        animator.SetInteger("talk", talkState);
    }

    public void SetDefeat()
    {
        defeatState = Random.Range(0, 1); // Elegir una de las dos animaciones de derrota al azar
        animator.SetInteger("lose", defeatState);
    }

    public void SetInteract()
    {
        animator.SetTrigger("thanks");
    }

    public void SetVictory()
    {
        animator.SetTrigger("win");
    }

    public void SetEasterEgg()
    {
        animator.SetTrigger("secret");
    }
}
