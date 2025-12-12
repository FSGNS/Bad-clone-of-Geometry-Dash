using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public float deathAnimationDuration = 1f;
    private bool isDead = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Danger"))
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        if (animator != null)
            animator.SetTrigger("Die");

        GameManager.Instance.PlayerDied(gameObject.tag);

        GetComponent<PlayerController>().enabled = false;
    }
}