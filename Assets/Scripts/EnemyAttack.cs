using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float timeBetweenAttack = 0.8f;
    [SerializeField]
    private AudioClip enemyAttackAudio;


    private float timer;
    private Animator animator;
    private EnemyHealth enemyHealth;


    private void Start()
    {
        timer = 0;
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }


    private void Update()
    {
        timer += Time.deltaTime;
    }


    private void OnTriggerStay(Collider other)
    {
        if (enemyHealth.health <= 0)
        {
            return;
        }
        if (other.gameObject.tag == "Player" && timer > timeBetweenAttack)
        {
            if (GameManager.gm == null || GameManager.gm.gameState == GameManager.GameState.Playing)
            {
                timer = 0;
                animator.SetBool("isAttack", true);
                if (enemyAttackAudio != null)
                {
                    AudioSource.PlayClipAtPoint(enemyAttackAudio, transform.position);
                }
                if (GameManager.gm != null)
                {
                    GameManager.gm.PlayerTakeDamage(damage);
                }
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            animator.SetBool("isAttack", false);
        }
    }
}
