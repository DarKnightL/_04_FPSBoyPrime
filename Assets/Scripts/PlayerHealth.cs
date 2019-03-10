using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
      
    public int health;
    public bool isAlive = true;

    private void Update()
    {
        if (health <= 0)
        {
            isAlive = false;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
        }
    }
}
