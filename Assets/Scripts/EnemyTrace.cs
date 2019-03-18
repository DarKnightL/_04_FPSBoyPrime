using UnityEngine;
using System.Collections;

public class EnemyTrace : MonoBehaviour {


    [SerializeField]
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

    }

    private void Update()
    {
        if (EnemyHealth!=null&&EnemyHealth.health<0)
        {

        }
    }

}
