using UnityEngine;
using System.Collections;


public class EnemyHealth : MonoBehaviour {
    public int health = 2;
    public int value = 1;
    [SerializeField]
    private AudioClip enemyHurtAudio;

    private Animator animator;
    private Rigidbody rigidbody;
    private CapsuleCollider collider;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if (enemyHurtAudio!=null)
        {
            AudioSource.PlayClipAtPoint(enemyHurtAudio, transform.position);
        }
        if (health<=0)
        {
            if (GameManager.gm!=null)
            {
                GameManager.gm.AddScore(value);
                animator.applyRootMotion = true;
                animator.SetTrigger("isDead");
                collider.enabled = false;
                rigidbody.useGravity = false;
                Destroy(gameObject, 3f);
            }
            
        }
    }



}
