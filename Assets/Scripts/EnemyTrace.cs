using UnityEngine;
using System.Collections;

public class EnemyTrace : MonoBehaviour
{


   
    public GameObject target;
    [SerializeField]
    private float minDist = 2.2f;
    [SerializeField]
    private float moveSpeed = 8f;


    private float dist;
    private Animator animator;
    private EnemyHealth enemyHealth;


    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (enemyHealth != null && enemyHealth.health < 0)
        {
            return;
        }
        if (target == null)
        {
            animator.SetBool("isStop", true);
            return;
        }
        dist = Vector3.Distance(transform.position, target.transform.position);
        if (GameManager.gm == null || GameManager.gm.gameState == GameManager.GameState.Playing)
        {
            if (dist > minDist)
            {
                transform.LookAt(target.transform.position);
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
            animator.SetBool("isStop", false);
        }
    }

}
