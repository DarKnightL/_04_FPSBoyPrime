using UnityEngine;
using System.Collections;

public class AutoCreateObject : MonoBehaviour
{


    [SerializeField]
    private GameObject createObject;
    [SerializeField]
    private GameObject traceTarget;

    [SerializeField]
    private float minSecond = 5.0f;
    [SerializeField]
    private float maxSecond = 10.0f;


    private float timer;
    private float createTime;



    private void Start()
    {
        if (traceTarget == null)
        {
            traceTarget = GameObject.FindGameObjectWithTag("Player");
        }
        timer = 0;
        createTime = Random.Range(minSecond, maxSecond);
    }


    private void Update()
    {
        if (GameManager.gm != null & GameManager.gm.gameState != GameManager.GameState.Playing)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer > createTime)
        {
            timer = 0;
            CreateEnemy();
            createTime = Random.Range(minSecond, maxSecond);
        }

    }

    private void CreateEnemy()
    {
        Vector3 dVector = new Vector3(0f, 5f, 0f);
        GameObject newProject = Instantiate(createObject, transform.position - dVector, Quaternion.identity) as GameObject;

        if (newProject.GetComponent<EnemyTrace>() != null)
        {
            newProject.GetComponent<EnemyTrace>().target = traceTarget;
        }

    }
}
