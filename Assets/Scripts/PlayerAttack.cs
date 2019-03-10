using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{



    [SerializeField]
    private int shootingDamage = 1;
    [SerializeField]
    private float shootingRange = 50f;
    [SerializeField]
    private AudioClip shootingAudio;
    [SerializeField]
    private float timeBetweenShooting = 1f;

    private Animator animator;
    private LineRenderer gunLine;

    private float timer;
    private Ray ray;
    private RaycastHit raycast;

    Camera mainCamera;


    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        gunLine = GetComponent<LineRenderer>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        timer = 0.0f;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && timer > timeBetweenShooting)
        {
            animator.SetBool("isShoot", true);
            timer = 0.0f;
            Invoke("Shoot", 0.5f);
        }
        else
        {
            timer += Time.deltaTime;
            animator.SetBool("isShoot", false);
            gunLine.enabled = false;
        }
    }


    private void Shoot()
    {

        AudioSource.PlayClipAtPoint(shootingAudio, transform.position);
        ray.origin = mainCamera.transform.position;
        ray.direction = mainCamera.transform.forward;

        gunLine.SetPosition(0, transform.position);

        if (Physics.Raycast(ray, out raycast, shootingRange))
        {
            if (raycast.collider.gameObject.tag == "Enemy")
            {
                EnemyHealth enemyHealth = raycast.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(shootingDamage);
                }
                if (enemyHealth.health > 0)
                {
                    raycast.collider.gameObject.transform.position += transform.forward * 2;
                }
                gunLine.SetPosition(1, transform.position);
            }

        }
        else
        
            gunLine.SetPosition(1, ray.origin + ray.direction * shootingRange);

        gunLine.enabled = true;

    }
}
